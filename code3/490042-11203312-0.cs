        public class User
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public Dep Dep { get; set; }
        }
        public class Dep
        {
            public int Id { get; set; }
            public User User { get; set; }
        }
        public class DepConfig : EntityTypeConfiguration<Dep>
        {
            public DepConfig()
            {
                this.HasRequired(t => t.User)
                        .WithOptional(t => t.Dep);
            }
        }
