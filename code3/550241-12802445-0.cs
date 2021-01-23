              public class SubjectDB  
             {  
                public string SubjectId  { get; set; }  
                .  
                .  
                public List<AddressDB> Address { get; set; }  
                .  
                .  
                [Key]  
                public int Id { get; set; }  
             }  
             public class DBEntities: DbContent  
             {  
                public DbSet<SubjectDB> SubjectDB { get; set; }  
                public DbSet<AddressDB> AddressDB { get; set; }  
                .  
                .  
             } 
