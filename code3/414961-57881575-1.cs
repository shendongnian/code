        private static readonly IDictionary<string, string> SPECIAL_FILTER_DICT = new Dictionary<string, string>
        {
            { nameof(YourEntityClass.ComplexAndCostProperty), "Some display text instead"},
            { nameof(YourEntityClass.Base64Image), ""},
            //...
        };
    
        
        public static IDictionary<string, string> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            if (source == null)
                return new Dictionary<string, string> {
                    {"",""}
                };
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null).GetSafeStringValue(propInfo.Name)
            );
        }
        public static String GetSafeStringValue(this object obj, String fieldName)
        {
            if (obj == null)
                return "";
            if (obj is DateTime)
                return GetStringValue((DateTime)obj);
            // More specical convert...
 
            if (SPECIAL_FILTER_DICT.ContainsKey(fieldName))
                return SPECIAL_FILTER_DICT[fieldName];
            // Override ToString() method if needs
            return obj.ToString();
        }
        private static String GetStringValue(DateTime dateTime)
        {
            return dateTime.ToString("YOUR DATETIME FORMAT");
        }
