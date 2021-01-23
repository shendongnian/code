    public static class DataRowHelpers
    {
        private static readonly Dictionary<Type, MethodInfo> FieldSpecialized = new Dictionary<Type, MethodInfo>();
    
        public static bool FieldHasValue(this DataRow row, Type type, string column)
        {
            MethodInfo fieldSpecialized;
            
            if(!FieldSpecialized.TryGetValue(type, out fieldSpecialized))
            {       
                var extensions = typeof(DataRowExtensions);
                var fieldGeneric = extensions.GetMethod("Field",
                                                        new[] { typeof(DataRow), typeof(string) });
                fieldSpecialized = fieldGeneric.MakeGenericMethod(type);
                
                FieldSpecialized.Add(type, fieldSpecialized);
            }
            
        
            return fieldSpecialized.Invoke(null, new object[] { row, column }) != null;
        }
    }
