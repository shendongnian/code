    public class DbAutoMapper<T> where T : IInitFromReader, new()
    {
        public IEnumerable<T> MapToList(IDataReader reader)
        {
            var list = new List<T>();
    
            while (reader.Read())
            {                
                IInitFromReader obj = new T;
    
                obj.InitFromReader(reader);
    
                list.Add(obj);
            }
            return list;
        }
    }
