    public class A
    {
        public string Response { get; set; }
        public string UUID { get; set; }
    }
    static void Main(string[] args)
    {
        var json = "[{\"Response\":\"OK\",\"UUID\":\"89172\"}, \"Response\":\"OK\",\"UUID\":\"10304\"}]";
        var result = JsonConvert.DeserializeObject<IEnumerable<A>>(json);
        foreach (var a in result)
            Console.WriteLine("Response: {0} UUID: {1}", a.Response, a.UUID);
        Console.ReadKey();
    }
