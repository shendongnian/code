    public class BlogRepository : BlogDb, IBlogRepository {
    ...
            public T Add<T>(T entity)
            {
                return Set<T>().Add(entity);
            }
    ...
    }
