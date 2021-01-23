    public class User {
            public Int32 Id { get; set; }
            public String Name { get; set; }
            public virtual ICollection<UserGroup> Groups { get; set; }
        }
        public class UserGroup {
            public Int32 Id { get; set; }
            public String Name { get; set; }
            public virtual ICollection<User> Users { get; set; }
            public virtual ICollection<UserGroupDynamicField> DynFields { get; set; }
        }
        public class UserGroupDynamicField {
            public Int32 Id { get; set; }
            public String Name { get; set; }
            public virtual UserGroup Group { get; set; }
        }
        
        
        public class UserGroupDynFEFCFConfiguration : EntityTypeConfiguration<UserGroupDynamicField > {
            public UserGroupDynFEFCFConfiguration()
                : base() {
                    HasRequired(x => x.Group);
            }
        }
        public class UserGroupEFCFConfiguration : EntityTypeConfiguration<UserGroup> {
            public UserGroupEFCFConfiguration()
                : base() {
                    HasMany(x => x.Users).WithMany(y => y.Groups);
            }
        }       
        public class TestEFContext : DbContext {
            public IDbSet<User> Users { get; set; }
            public IDbSet<UserGroup> Groups { get; set; }
            public TestEFContext(String cs)
                : base(cs) {
                Database.SetInitializer<TestEFContext>(new DropCreateDatabaseAlways<TestEFContext>());
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Configurations.Add(new UserGroupDynFEFCFConfiguration());
                modelBuilder.Configurations.Add(new UserGroupEFCFConfiguration());
            }
        }
        class Program {
            static void Main(String[] args) {
                String cs = @"Data Source=ALIASTVALK;Initial Catalog=TestEF;Integrated Security=True; MultipleActiveResultSets=True";
                using (TestEFContext c = new TestEFContext(cs)) {
                    UserGroup g1 = new UserGroup {
                        Name = "G1",
                        DynFields = new List<UserGroupDynamicField> { 
                            new UserGroupDynamicField { Name = "DF11"},
                            new UserGroupDynamicField { Name = "DF12"}
                        }
                    };
                    c.Groups.Add(g1);
                    UserGroup g2 = new UserGroup {
                        Name = "G2",
                        DynFields = new List<UserGroupDynamicField> { 
                            new UserGroupDynamicField { Name = "DF21"},
                            new UserGroupDynamicField { Name = "DF22"}
                        }
                    };
                    c.Groups.Add(g2);
                    c.Users.Add(new User {
                        Name = "U1",
                        Groups = new List<UserGroup> { g1, g2 }
                    });
                    c.SaveChanges();
                }      
                
                using (TestEFContext c = new TestEFContext(cs)) {
                    var res = c.Users.Include("Groups.DynFields").First().Groups.SelectMany(x => x.DynFields).ToList();
                    foreach (var v in res) {
                        Console.WriteLine(v.Name);
                    } 
                }
            }
        }
