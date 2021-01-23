    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    namespace EFInclude
    {
        public class Harbor
        {
            public int HarborId { get; set; }
            public virtual ICollection<Ship> Ships { get; set; }
            public string Description { get; set; }
        }
        public class Ship
        {
            public int ShipId { get; set; }
            public int HarborId { get; set; }
            public virtual Harbor Harbor { get; set; }
            public virtual ICollection<CrewMember> CrewMembers { get; set; }
            public string Description { get; set; }
        }
        public class CrewMember
        {
            public int CrewMemberId { get; set; }
            public int ShipId { get; set; }
            public virtual Ship Ship { get; set; }
            public int RankId { get; set; }
            public virtual Rank Rank { get; set; }
            public int ClearanceId { get; set; }
            public virtual Clearance Clearance { get; set; }
            public string Description { get; set; }
        }
        public class Rank
        {
            public int RankId { get; set; }
            public virtual ICollection<CrewMember> CrewMembers { get; set; }
            public string Description { get; set; }
        }
        public class Clearance
        {
            public int ClearanceId { get; set; }
            public virtual ICollection<CrewMember> CrewMembers { get; set; }
            public string Description { get; set; }
        }
        public class MyContext : DbContext
        {
            public DbSet<Harbor> Harbors { get; set; }
            public DbSet<Ship> Ships { get; set; }
            public DbSet<CrewMember> CrewMembers { get; set; }
            public DbSet<Rank> Ranks { get; set; }
            public DbSet<Clearance> Clearances { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
                using (var context = new MyContext())
                {
                    context.Database.Initialize(true);
                    var harbor = new Harbor
                    {
                        Ships = new HashSet<Ship>
                        {
                            new Ship
                            {
                                CrewMembers = new HashSet<CrewMember>
                                {
                                    new CrewMember
                                    {
                                        Rank = new Rank { Description = "Rank A" },
                                        Clearance = new Clearance { Description = "Clearance A" },
                                        Description = "CrewMember A"
                                    },
                                    new CrewMember
                                    {
                                        Rank = new Rank { Description = "Rank B" },
                                        Clearance = new Clearance { Description = "Clearance B" },
                                        Description = "CrewMember B"
                                    }
                                },
                                Description = "Ship AB"
                            },
                            new Ship
                            {
                                CrewMembers = new HashSet<CrewMember>
                                {
                                    new CrewMember
                                    {
                                        Rank = new Rank { Description = "Rank C" },
                                        Clearance = new Clearance { Description = "Clearance C" },
                                        Description = "CrewMember C"
                                    },
                                    new CrewMember
                                    {
                                        Rank = new Rank { Description = "Rank D" },
                                        Clearance = new Clearance { Description = "Clearance D" },
                                        Description = "CrewMember D"
                                    }
                                },
                                Description = "Ship CD"
                            }
                        },
                        Description = "Harbor ABCD"
                    };
                    context.Harbors.Add(harbor);
                    context.SaveChanges();
                }
                using (var context = new MyContext())
                {
                    DbSet<Harbor> dbSet = context.Set<Harbor>();
                    IQueryable<Harbor> query = dbSet;
                    query = query.Include(entity => entity.Ships);
                    query = query.Include(entity => entity.Ships.Select(s => s.CrewMembers));
                    query = query.Include(entity => entity.Ships.Select(s => s.CrewMembers.Select(cm => cm.Rank)));
                    query = query.Include(entity => entity.Ships.Select(s => s.CrewMembers.Select(cm => cm.Clearance)));
                
                    var harbor = query.Single();
                    Console.WriteLine("Harbor {0} Description = \"{1}\"",
                        harbor.HarborId, harbor.Description);
                    foreach (var ship in harbor.Ships)
                    {
                        Console.WriteLine("- Ship {0} Description = \"{1}\"",
                            ship.ShipId, ship.Description);
                        foreach (var crewMember in ship.CrewMembers)
                        {
                            Console.WriteLine("-- CrewMember {0} Description = \"{1}\"", 
                                crewMember.CrewMemberId, crewMember.Description);
                            Console.WriteLine("-- CrewMember {0} Rank Description = \"{1}\"",
                                crewMember.CrewMemberId, crewMember.Rank.Description);
                            Console.WriteLine("-- CrewMember {0} Clearance Description = \"{1}\"",
                                crewMember.CrewMemberId, crewMember.Clearance.Description);
                        }
                    }
                    Console.ReadLine();
                }
            }
        }
    }
