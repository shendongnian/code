    {
        public class Data
        {
            public int ID { get; set; }
            public DateTime Arrival_Time { get; set; }
        }
        public class DataDBContext : DbContext
        {
            public DbSet<Data> Queue { get; set; }
        } 
    }
