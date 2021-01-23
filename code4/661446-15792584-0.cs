    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Objects.SqlClient;
    namespace testef {
        //Model
        public class CObj {
            public CObj() {
            }
            public Int32 Id { get; set; }
            public String SomeCol { get; set; }
        }
        //Configuration for CObj
        public class CObjConfiguration : EntityTypeConfiguration<CObj> {
            public CObjConfiguration() {
                HasKey(x => x.Id);
            }
        }
        public class TestEFContext : DbContext {
            public IDbSet<CObj> objects { get; set; }
            public TestEFContext(String cs)
                : base(cs) {
                Database.SetInitializer<TestEFContext>(new DropCreateDatabaseAlways<TestEFContext>());
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Configurations.Add(new CObjConfiguration());
            }
        }
        class Program {
            static void Main(String[] args) {
                String cs = @"Data Source=ALIASTVALK;Initial Catalog=TestEF;Integrated Security=True; MultipleActiveResultSets=True";                
                using (TestEFContext c = new TestEFContext(cs)) {
                    c.objects.Add(new CObj { Id = 1, SomeCol = "c"});
                    c.SaveChanges();
                }
                IEnumerable<String> ks = new List<String> { String.Format("{0,10}-c", 1) };
                foreach (var k in ks) {
                    Console.WriteLine(k);
                }
                
                using (TestEFContext c = new TestEFContext(cs)) {
                    var vs = from o in c.objects
                             where ks.Contains(SqlFunctions.StringConvert((Decimal?)o.Id, 10) + "-" + o.SomeCol)
                             select o;
                    foreach (var v in vs) {
                        Console.WriteLine(v.Id);
                    }
                }
                
            }
        }
    }
