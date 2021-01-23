    // I made up a Material class for testing:
    public class Materiel
    {
        public string A { get; set; }
        public int B { get; set; }
        public DateTime? C { get; set; }
        public string D { get; set; }
        public Nested E { get; set; }
    }     
    // [...] usage:
    foreach (var pattern in new[]{ "World" , "dick", "Dick", "ick", "2012", "Attach" })
        Console.WriteLine("{0} records match '{1}'", Database.Search(pattern).Count(), pattern);
