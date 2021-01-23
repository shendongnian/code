    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    namespace ConsoleApplication1
    {
        [Table("MyEntity")]    
        public class MyEntity
        {
            private Collection<MyRelatedEntity> relatedEntities;
            [Key]
            public virtual int MyEntityId { get; set; }
            [DataType(DataType.Date)]
            public virtual DateTime MyDate { get; set; }
            [InverseProperty("MyEntity")]
            public virtual ICollection<MyRelatedEntity> RelatedEntities
            {
                get
                {
                    if (this.relatedEntities == null)
                    {
                        this.relatedEntities = new Collection<MyRelatedEntity>();
                    }
                    return this.relatedEntities;
                }
            }
            public override string ToString()
            {
                return string.Format("Date: {0}; Related: {1}", this.MyDate, string.Join(", ", this.RelatedEntities.Select(q => q.SomeString).ToArray()));
            }
        }
        public class MyRelatedEntity
        {
            [Key]
            public virtual int MyRelatedEntityId { get; set; }
            public virtual int MyEntityId { get; set; }
            [ForeignKey("MyEntityId")]
            public virtual MyEntity MyEntity { get; set; }
            public virtual string SomeString { get;set;}
        }
        public class MyContext : DbContext
        {
            public DbSet<MyEntity> MyEntities
            {
                get { return this.Set<MyEntity>(); }
            }
        }
        class Program
        {
            const string SqlQuery = @"DECLARE @date date; SET @date = @dateIn; SELECT * FROM MyEntity WHERE MyDate > @date";
            static void Main(string[] args)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
                using (MyContext context = new MyContext())
                {
                    context.MyEntities.Add(new MyEntity
                        {
                            MyDate = DateTime.Today.AddDays(-2),
                            RelatedEntities =
                            {
                                new MyRelatedEntity { SomeString = "Fish" },
                                new MyRelatedEntity { SomeString = "Haddock" }
                            }
                        });
                    context.MyEntities.Add(new MyEntity
                    {
                        MyDate = DateTime.Today.AddDays(1),
                        RelatedEntities =
                            {
                                new MyRelatedEntity { SomeString = "Sheep" },
                                new MyRelatedEntity { SomeString = "Cow" }
                            }
                    });
                    context.SaveChanges();
                }
                using (MyContext context = new MyContext())
                {
                    IEnumerable<MyEntity> matches = context.MyEntities.SqlQuery(
                        SqlQuery,
                        new SqlParameter("@dateIn", DateTime.Today)).ToList();
                    // The implicit ToString method call here invokes lazy-loading of the related entities.
                    Console.WriteLine("Count: {0}; First: {1}.", matches.Count(), matches.First().ToString());
                }
                Console.Read();
            }
        }
    }
