    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;
    namespace EFTest
    {
        public class Two
        {
            public int TwoId { get; set; }
            public string OneId { get; set; }
            public virtual One One { get; set; }
        }
        public class One
        {
            public string OneId { get; set; }
            public virtual ICollection<Two> Twos { get; private set; }
            // Comment out this property and it will work
            public int SomeInt { get; set; }
            public void AddTwo(Two two)
            {
                if (two == null)
                    throw new ArgumentNullException("two");
                if (Twos == null)
                    Twos = new List<Two>();
                if (!Twos.Contains(two))
                    Twos.Add(two);
                two.One = this;
            }
        }
        public class Context : DbContext
        {
            public Context(string connectionString)
                : base(connectionString)
            {
                Configuration.LazyLoadingEnabled = true;
                Ones = Set<One>();
                Twos = Set<Two>();
            }
            public DbSet<One> Ones { get; private set; }
            public DbSet<Two> Twos { get; private set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder
                    .Entity<One>()
                    .HasKey(d => d.OneId)
                    .ToTable("One");
                var two = modelBuilder.Entity<Two>();
                two.ToTable("Two");
                two.HasKey(d => new
                                    {
                                        d.OneId,
                                        d.TwoId
                                    });
                two.Property(d => d.TwoId)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
                two.HasRequired(m => m.One)
                    .WithMany(t => t.Twos)
                    .HasForeignKey(d => d.OneId);
                base.OnModelCreating(modelBuilder);
            }
        }
        internal class Program
        {
            private static void Main()
            {
                using (var ctx = new Context(@"your connection string"))
                {
                    const string oneId = "1";
                    var one = ctx.Ones.Single(o => o.OneId.Equals(oneId));
                    if (one == null)
                    {
                        Console.WriteLine("No row with one ID in the database");
                        return;
                    }
                    var two = ctx
                        .Twos
                        .Include(s => s.One)
                        .Single(s => s.OneId.Equals(oneId));
                    Console.WriteLine(two.One == null
                                          ? "SHOULD NOT BE PRINTED!!!"
                                          : "SHOULD BE PRINTED");
                }
            }
        }
    }
