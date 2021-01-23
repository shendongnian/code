    public class MyClass
    {
        private readonly int[] _default = new[] { 1, 2, 3, 4 }
        public static void init(int[] myArray = null) {
            if (myArray = null)
            {
                // Don't modify _default to ensure thread safe
                myArray = _default;
            }
            //Do Something
        }
    }
