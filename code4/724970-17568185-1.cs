    public static class TypeExtensions {
        public static MethodInfo GetMethod(this Type type, string name, BindingFlags bindingAttr, Type[] types, Type returnType ) {
            var methods = type
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(mi => mi.Name == "op_Explicit")
                .Where(mi => mi.ReturnType == typeof(int));
            
            if (!methods.Any())
                return null;
            
            if (methods.Count() > 1)
                throw new System.Reflection.AmbiguousMatchException();
                
            
            return methods.First();
        }
    
        public static MethodInfo GetExplicitCastToMethod(this Type type, Type returnType ) 
        {
            return type.GetMethod("op_Explicit", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { type }, returnType);
        }
    }
