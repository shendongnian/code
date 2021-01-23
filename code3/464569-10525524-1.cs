    internal void TestableEquiptmentRepository: EquiptmentRepository
    {
        internal List<Manufacturer> AddedManufacturers = new List<Manufacturer>();
        protected override void AddToDbSet(Manufacturer m)
        {
            // we're no longer calling DbSet.Add but kind of rolling
            // our own basic mock and tracking what objects were
            // add by simply adding them to internal list
            this.AddedManufacturers.Add(m);
        }
    }
