        public static class ClassNameExtension
    {
        // must have different signature to prevent memory exception
        public static string MethodToOverid(this ClassName class, List<T> tochange)
        {
            tochange.add(class)
            class.originalmethod()
        }
    }
