    static void Main(string[] args)
    {
        Console.WriteLine(JsonConvert.SerializeObject(new Test()));
    }
    public class Test
    {
        public string Test1 { get { return "test1"; } }
        public string Test2 { get { return Test2Func(); } }
        private string Test2Func()
        {
            return "test2";
        }
    }
