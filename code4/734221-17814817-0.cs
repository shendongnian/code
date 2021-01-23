    public interface IExtendedDbSet<T> : IDbSet<T> {
        DbSqlQuery SqlQuery(string sql, object[] parameters);
    }
    public class ExtendedDbSet<T> : IExtendedDbSet<T> {
        private DbSet<T> _dbSet;
        public ExtendedDbSet(DbSet<T> dbSet) { _dbSet = dbSet; }
        DbSqlQuery<T> IExtendedDbSet<T>.SqlQuery(sql, parameters) {
            return _dbSet.SqlQuery(sql, parameters);
        }
        public T Add(T entity) { return _dbSet.Add(entity); }
        // Write public wrappers around each of the other properties/methods
        // that you need for DbSet<T>
    }
