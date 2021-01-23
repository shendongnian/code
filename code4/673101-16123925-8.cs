    public class TestRepository : DataRepository<DataRepositoryIntegrationTest>
    {
        public TestRepository(DataContext context)
            : base(context,  (item1, item2) => item1.Id == item2.Id)
        { }
        protected override void UpdateExisting(DataRepositoryIntegrationTest existing, DataRepositoryIntegrationTest item)
        {
            existing.Value = item.Value;
            existing.DateUpdated = DateTime.Now;
        }
    }
