    class Program
    {
        static void Main(string[] args)
        {
            Beer b = new Beer();
            var beerStore = IConstructStore(b);
            Console.WriteLine(beerStore.test);
            Console.WriteLine(beerStore.GetType().ToString());
        }
        public static Store<T> IConstructStore<T>(T item) where T : IStorable
        {
            return Activator.CreateInstance(typeof(Store<T>), new object[] { }) as Store<T>;
        }
    }
    interface IStorable { }
    class Store<T> where T : IStorable
    {
        public int test = 1;
    }
    class Beer : IStorable
    { }
