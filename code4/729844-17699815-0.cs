    public class DummyKlasse
    {
        public List<string> List { get; set; }
        public DummyKlasse() 
        {
            List = new List<string>();
        }
        public void Setup()
        {
            List.Add("one");
            List.Add("two");
        }
    }
    ...
    var dummy = new DummyKlasse();
    dummy.Setup();
    // the client does his own enumerating, not dummy.
    foreach (var str in dummy.List)   
    {
        Console.WriteLine(str);
    }
