       class Program
        {
            static void Main(string[] args)
            {
                var list = new List<string>
                (
                    Generator.New(() => new string('a', 5), 100)
                );
    
                list.ForEach((x) => Console.WriteLine(x));
            }
        }
    
        public static class Generator
        {
            public static IEnumerable<T> New<T>(Func<T> generator, int nCount)
            {
                for (int i = 0; i < nCount; i++)
                {
                    yield return generator();
                }
            }
    
            public static IEnumerable<T> New<T>(Func<int,T> generator, int nCount)
            {
                for (int i = 0; i < nCount; i++)
                {
                    yield return generator(i);
                }
            }
        }
