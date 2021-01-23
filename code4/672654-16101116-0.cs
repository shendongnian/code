    public class Foo {
        public List<Tuple<string, string, bool>> Items { get; set; }
        public Foo()
        {
            Items = new List<Tuple<string, string, bool>>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in Items)
            {
                sb.Append(a.Item1 + ", " + a.Item2 + ", " + a.Item3.ToString() + "\r\n");
            }
            return sb.ToString();
        }
    }
    [TestClass]
    public class NormalTests
    {
        [TestMethod]
        public void TupleSerialization()
        {
            Foo tests = new Foo();
            tests.Items.Add(Tuple.Create("one", "hehe", true));
            tests.Items.Add(Tuple.Create("two", "hoho", false));
            tests.Items.Add(Tuple.Create("three", "ohoh", true));
            string json = JsonConvert.SerializeObject(tests);
            Console.WriteLine(json);
            var obj = JsonConvert.DeserializeObject<Foo>(json);
            string objStr = obj.ToString();
            Console.WriteLine(objStr);
        }
    }
