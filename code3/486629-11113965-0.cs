    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository()
        {
            this.Context = new System.Data.Linq.DataContext()
        }
    }
