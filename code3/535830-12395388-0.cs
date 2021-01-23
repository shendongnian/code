    public class DbAutoMapper<T> where T : IInitFromReader
    {
        public IEnumerable<T> MapToList(IDataReader reader)
        {
            var list = new List<T>();
    
            while (reader.Read())
            {                
                IInitFromReader obj = Activator.CreateInstance<T>();
    
                obj.InitFromReader();
    
                list.Add(obj);
            }
            return list;
        }
    }
