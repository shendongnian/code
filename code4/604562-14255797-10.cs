    public interface IRepository<T>
    {
        int Save(T entity);
    }
    public class CodeRepository : IRepository<Code>
    {
        public int Save(Code entity)
        {
            using (var context = new Context())
            {
                context.Code.Add(entity);
                context.SaveChanges();
            }
        }
    }
