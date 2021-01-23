    static class CategoryExtensions
    {
        public static T[] GetChildren<T>(this Category parent)
            where T : Category, new()
        {
            // Do whatever...
        }
    }
