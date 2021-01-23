    class EventType
    {
        int id { get; set; }
        string name { get; set; }
        DateTime date { get;  set; }
        List<int> list { get; set; }
        Guid guid { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EventType event1 = new EventType();
            int rate = 100;
            DataGenerator.Generate<EventType>(event1, rate);
        }
        public static byte[] test(EventType newEvent)
        {
            return new byte[1];
        }
    }
    static class DataGenerator
    {
        public static void Generate<T>(T input, int eventRate, Func<T, byte[]> serializer = null)
        {
            Type t = input.GetType();
            PropertyInfo[] properties = t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.ToString());
            }
            //var bytes = serializer(input);
        }
    }
