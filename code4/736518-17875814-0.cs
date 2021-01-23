    public static class OutputExtensions
    {
        public static void Export<T>(this List<T> list)
        {
            // get properties of Model
            PropertyInfo[] properties = typeof(T).GetProperties();
    
            foreach (var property in properties)
            {
                if (property.CanRead)
                    PRINTOUT(property.Name);
            }
    
            foreach (var entity in list)
            {
                foreach (var property in properties)
                {
                    if (property.CanRead)
                        PRINTOUT(property.GetValue(entity, null));
                }
            }
        }
    }
