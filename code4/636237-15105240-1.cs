    class Program
    {
        static void Main(string[] args)
        {
            var obj1 = new List<SomeOBject1>();
            var obj2 = new List<SomeOBject2>();
            var randomData1 = new SomeOBject1 { Id1 = 1, SomeData1 = "one" };
            var randomData2 = new SomeOBject2 { Id2 = 1, SomeData2 = "two", End = DateTime.Now, Start = DateTime.Now };
            obj1.Add(randomData1);
            obj2.Add(randomData2);
            var bound = obj1.Join(obj2, o1 => o1.Id1, o2 => o2.Id2, (o1, o2) => new {o1, o2.Start, o2.End});
        }
    }
    public class SomeOBject1
    {
        public int Id1 { get; set; }
        public string SomeData1 { get; set; }
    }
    public class SomeOBject2
    {
        public int Id2 { get; set; }
        public string SomeData2 { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
