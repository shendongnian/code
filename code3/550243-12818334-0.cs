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
            public SubjectDB()
            {
               this.Address = new List<AddressDB>();
               .
               .
            }   
         }   
         public class DBEntities: DbContent   
         {   
            public DbSet<SubjectDB> SubjectDB { get; set; }   
            public DbSet<AddressDB> AddressDB { get; set; }   
            .   
            .   
         } 
