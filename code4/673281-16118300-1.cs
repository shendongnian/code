    public class DtoMapper<DtoType>
    {
        Dictionary<string,PropertyInfo> properties;
        public DtoMapper()
        {
            // Cache property infos
            var t = typeof(DtoType);
            properties = t.GetProperties().ToDictionary(p => p.Name, p => p);
         }
    
        public DtoType Map(Dto dto)
        {
            var instance = Activator.CreateInstance(typeOf(DtoType));
           
            foreach(var p in properties)
            {
                p.SetProperty(
                    instance, 
                    Convert.Type(
                        p.PropertyType, 
                        dto.Items[Array.IndexOf(dto.ItemsNames, p.Name)]);
                return instance;
            }
        }
