    public class Foo
    {
        public static List<long> GetList(EfEntities dbContext)
        {
            return dbContext.SomeTable.Where(x => x == 1).ToList();
        }
    }
