    [AttributeUsage(AttributeTargets.Field)]
    sealed class SomeAttribute: Attribute
    {
        public SomeAttribute()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(Thing);
            var attrs = from f in t.GetFields()
                        from a in f.GetCustomAttributes()
                        select new { Name = f.Name, Attribute = a.GetType() };
            foreach (var a in attrs)
                Console.WriteLine(a.Name + ": " + a.Attribute);
            Console.ReadLine();
        }
    }
