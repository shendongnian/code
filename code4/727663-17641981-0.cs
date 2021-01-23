    namespace Something
    {
        public class Conditional<T>
        {
            private List<T> _something = new List<T>();
            private Conditional()
            {
                // prevents instantiation except through Create method
            }
            public Conditional<T> Create()
            {
                // here check if T is int or short
                // if it's not, then throw an exception
                return new Conditional<T>();
            }
        }
    }
