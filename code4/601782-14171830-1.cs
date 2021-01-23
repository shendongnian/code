    public static class ArrayExtension {
      
        public static bool Any<T>(this T[] source, Func<T,bool> predicate)
        {
           Console.WriteLine("Undesirable side behaviour");
           SomeResourceIntensiveOperation();
           
           Console.WriteLine("Inefficient implementation");
           return source.Where(predicate).Count() != 0;
        }
    
    }
