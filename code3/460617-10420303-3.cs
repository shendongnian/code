    public MyDbContext: DbContext { 
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Vehicle> Vehicles { set; get; }
    }
