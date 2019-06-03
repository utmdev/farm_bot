﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(FarmBotDbContext))]
    partial class FarmBotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entites.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Info")
                        .HasMaxLength(250);

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Entites.FarmBot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(15);

                    b.Property<string>("IpCameraAddress")
                        .HasMaxLength(50);

                    b.Property<int>("LastX");

                    b.Property<int>("LastY");

                    b.Property<int>("Length");

                    b.Property<string>("Name")
                        .HasMaxLength(75);

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Width");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("FarmBots");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99d9742b-1ee2-45c9-a9fb-8742baa3bb86"),
                            Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IpAddress = "192.168.1.112",
                            IpCameraAddress = "http://192.168.1.1:8080/video",
                            LastX = 0,
                            LastY = 0,
                            Length = 0,
                            Name = "Utm FarmBot",
                            Updated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Width = 0
                        });
                });

            modelBuilder.Entity("Entites.Parameters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AirTemperature");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("FarmBotId");

                    b.Property<byte>("Luminosity");

                    b.Property<int>("SeededPlants");

                    b.Property<byte>("SoilHumidity");

                    b.HasKey("Id");

                    b.HasIndex("FarmBotId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("Entites.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<short>("Duration");

                    b.Property<string>("Info")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PlantDistance");

                    b.Property<int>("RowDistance");

                    b.Property<short>("SeedDepth");

                    b.Property<byte>("SoilHumidity");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("Entities.FarmBotPlant", b =>
                {
                    b.Property<Guid>("FarmBotId");

                    b.Property<Guid>("PlantId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Updated");

                    b.HasKey("FarmBotId", "PlantId");

                    b.HasIndex("PlantId");

                    b.ToTable("FarmBotPlants");
                });

            modelBuilder.Entity("Entites.Parameters", b =>
                {
                    b.HasOne("Entites.FarmBot", "FarmBot")
                        .WithMany()
                        .HasForeignKey("FarmBotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Entities.FarmBotPlant", b =>
                {
                    b.HasOne("Entites.FarmBot", "FarmBot")
                        .WithMany("FarmBotPlants")
                        .HasForeignKey("FarmBotId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Entites.Plant", "Plant")
                        .WithMany("FarmBotPlants")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
