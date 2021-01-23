    public static class EfEntitiesExtensions
    {
        public static readonly List<long> FirstList(this EfEntities dbContext)
        {
            return dbContext.SomeTable.Where(x => x == 1).ToList();
        }
        public static readonly List<long> SecondList(this EfEntities dbContext)
        {
            return dbContext.SomeTable.Where(x => x == 2).ToList();
        }
    }
