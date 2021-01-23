    public class YourDatabaseContext : DbContext
    {
        public DbSet<IxDetails> IxDetailRecords { get; set; }
    }
    public class DataLoader
    {    
        public void AddRecords()
        {
            using (var db = new YourDatabaseContext())
            {
                var newRecord = new IxDetailRecord {... };
                db.IxDetailRecords.Add(newRecord);
                db.Save();
            }
        }
    }
