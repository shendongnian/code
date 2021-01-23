    // Choose appropriate names for these classes
    class Foo
    {
        public Dictionary<string, string> Head { get; set; }
        public List<Bar> Body { get; set; }
    }
    
    class Bar
    {
        public Dictionary<string, string> RowId { get; set; }
    }
    static void Main(string[] args)
    {
        string json = "{  **data removed - request from owner**} }]}";
        var result = JsonConvert.DeserializeObject<Foo>(json);
        foreach (string value in result.Body.First().RowId.Keys)
        {
            Console.WriteLine(value);
        }
    }
