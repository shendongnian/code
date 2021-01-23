    class Program
    {
        static void Main(string[] args)
        {
            PlaceRoom<Room>();
            Console.ReadKey(true);
        }
        public static void PlaceRoom<T>()
            where T : Room
        {
            string name = ((NameAttribute)typeof(T).GetCustomAttributes(false).First(x => x is NameAttribute)).Name;
            Console.WriteLine(name);
        }
    }
    [Name("Room")]
    public class Room
    {
    }
    [Name("Bedroom")]
    public class Bedroom : Room
    {
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class NameAttribute : Attribute
    {
        public string Name { get; set; }
        public NameAttribute(string name)
        {
            Name = name;
        }
    }
