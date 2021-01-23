    public class Foo
    {
        private bool _field;
    
        public static class Extensions
        {
            public static bool GetField(*this* Foo foo) // not allowed, compile error.
            {
                return foo._field;
            }
        }
    }
