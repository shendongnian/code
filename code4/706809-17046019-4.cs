    public class PropertyWrapper<T>
    {
        readonly Action<T> set;
        readonly Func<T>   get;
        public PropertyWrapper(Func<T> get, Action<T> set)
        {
            this.get = get;
            this.set = set;
        }
        public T Value
        {
            get
            {
                return get();
            }
            set
            {
                set(value);
            }
        }
    }
    public class Test
    {
        public string Item
        {
            get;
            set;
        }
    }
    class Program
    {
        void run()
        {
            Test test = new Test
            {
                Item = "Initial Item"
            };
            Console.WriteLine(test.Item); // Prints "Initial Item"
            var wrapper = new PropertyWrapper<string>(() => test.Item, value => test.Item = value);
            Console.WriteLine(wrapper.Value); // Prints "Initial Item"
            wrapper.Value = "Changed Item";
            Console.WriteLine(wrapper.Value); // Prints "Changed Item"
        }
        static void Main()
        {
            new Program().run();
        }
    }
