     class Program
        {
            static void Main(string[] args)
            {
                List<long> ids = new List<long> { 1, 2, 3 };
    
                //Non generic way
                List<Data> dataItems = ids.ConvertToDataItems();
    
                //Generic attempt!!
    
                Func<long, Data> selector = (p => new Data { DataId = p });
                List<Data> differntDataItems = ids.ConvertToEntities<Data>(selector);
            }
        }
    
    
        public class Data
        {
            public long DataId;
            public string Name;
        }
    
        public static class ExtensionMethods
        {
            public static List<Data> ConvertToDataItems(this List<long> dataIds)
            {
                return dataIds.Select(p => new Data { DataId = p }).ToList();
            }
    
            public static List<TProp> ConvertToEntities<TProp>(this List<long> entities, Func<long, TProp> selector)
            {
                return entities.Select(selector).ToList();
            }
        }
