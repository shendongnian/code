    public struct Person
    {
        int id;
        string name;
        public Person(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public override string ToString()
        {
            return string.Format("ID={0} Name={1}", id, name);
        }
    }
    class Program
    {
        public static T Factory<T>()
            where T : struct
        {
            return default(T);
        }
        public static T Factory<T>(params object[] args)
            where T : struct
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
        static void Main(string[] args)
        {
            Person p = Factory<Person>(1001, "John");
            Console.WriteLine("{0}", p);
        }
    }
