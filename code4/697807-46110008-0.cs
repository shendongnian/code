      public class ZooPen<T> where T : Animal
        {
            public ZooPen()
            {
                if (typeof(T).IsAbstract)
                    throw new ArgumentException(typeof(T).Name + " must be non abstract class");
            }
        }
