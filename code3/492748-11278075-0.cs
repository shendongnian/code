    public class BlogRepository : BlogDb, IBlogRepository {
    ...
            T IBlogRepository.Add<T>(T entity)
            {
                return Set<T>().Add(entity);
            }
    ...
    }
