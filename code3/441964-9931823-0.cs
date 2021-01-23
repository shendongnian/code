        static void Main(string[] args)
        {
            object a = new object();
            object v = TryGetArrayValue<object>(new object[] { a }, 0);
            Console.ReadLine();
        }
        public static T TryGetArrayValue<T>(object[] array_, int index_)
        {
                T boxed = (T)array_[index_];
                return boxed;
          
        }
