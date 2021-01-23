    public static class SomeExtensions {
        private static readonly MethodInfo methodDefOf_PrivateHelper = typeof(SomeExtensions)
            .GetMethod("PrivateHelper", 
                       BindingFlags.NonPublic | BindingFlags.Static, 
                       Type.DefaultBinder, 
                       new [] { typeof(System.Collections.IEnumerable) }, 
                       null);
        private static IEnumerable<T> PrivateHelper<T>(System.Collections.IEnumerable @this){
            foreach (var @object in @this)
                yield return (T)@object; // right here is were you can get the cast exception
        }
        public static System.Collections.IEnumerable DynamicCast(
            this System.Collections.IEnumerable @this,
            Type elementType
        ) {
            MethodInfo particularizedMethod = SomeExtensions.methodDefOf_PrivateHelper
                .MakeGenericMethod(elementType);
            object result = particularizedMethod.Invoke(null, new object[] { @this });
            return result as System.Collections.IEnumerable;
        }
    
    }
