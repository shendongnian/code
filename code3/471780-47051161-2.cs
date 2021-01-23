    public abstract class AbstractRepository<T>: IRepository<T> where T : Identity
        {
            protected abstract string TableName { get; }
    
            protected abstract T DataRowToModel(DataRow dr);
    
            protected virtual ICollection<T> DataTableToCollection(DataTable dt)
            {
                if (dt == null)
                {
                    return null;
                }
                return dt.AsEnumerable().Select(x => DataRowToModel(x)).ToList();
            }
    
            public virtual T GetById(int id)
            {
                var query = $"select * from {TableName} where id = {id}";
                //the data access layer is implemented elsewhere
                DataRow dr = DAL.SelectDataRow(query); 
                return DataRowToModel(dr);
            }
    
            public virtual void Delete(T entity)
            {
                if (entity.Id == 0 )
                {
                    return;
                }
                var query = $"delete from {TableName} where id = {entity.Id}";
                DAL.Query(query);
            }
    
            public virtual void Delete(ICollection<T> entityes)
            {
                var collectionId = IdentityCollectionToSqlIdFormat(entityes);
                if (string.IsNullOrEmpty(collectionId))
                {
                    return;
                }
                var query = $"delete from {TableName} where id in ({collectionId})";
                DAL.Query(query);
            }
    
            public virtual ICollection<T> GetAll()
            {
                var query = $"select * from {TableName}";
                DataTable dt = DAL.SelectDataTable(query);
                return DataTableToCollection(dt);
            }
    
            public virtual ICollection<T> GetAll(string where)
            {
                var query = $"select * from {TableName} where {where}";
                DataTable dt = DAL.SelectDataTable(query);
                return DataTableToCollection(dt);
            }
    
            protected virtual string IdentityCollectionToSqlIdFormat(ICollection<T> collection)
            {
                var array = collection.Select(x => x.Id);
                return string.Join(",", array);
            }
    
    
            public abstract int GetIdByEntity(T entity);
            public abstract bool Update(T entity);
            public abstract bool Insert(T entity);
        }
