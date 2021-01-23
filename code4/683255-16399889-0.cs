    public class ListMapper : IMapper 
    {
        public void GetTableInfo(Type t, TableInfo ti)
        {
        }
        public bool MapPropertyToColumn(PropertyInfo pi, ref string columnName, ref bool resultColumn)
        {
            return true;
        }
        public Func<object, object> GetFromDbConverter(PropertyInfo pi, Type sourceType)
        {
            return src => 
                {
                    if (sourceType == typeof (string)
                        && pi.PropertyType == typeof (List<string>)
                        && src != null)
                    {
                        return ((string) src).Split(';').ToList();
                    }
                    return src;
                };
        }
        public Func<object, object> GetToDbConverter(Type sourceType)
        {
            return null;
        }
    }
---
    Database.Mapper = new ListMapper(); // Mapper is a static property
