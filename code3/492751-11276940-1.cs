    void Main()
    {
        List<SomeClass> list = new List<SomeClass>() {
            new SomeClass() { Kind = null, Name = "E" },
            new SomeClass() { Kind = null, Name = "W" },
            new SomeClass() { Kind = 4, Name = "T" },
            new SomeClass() { Kind = 5, Name = "G" },
            ...
        };
    
        var query = list.Where ((s, i) =>
            !s.Kind.HasValue &&
            list.ElementAtOrDefault(i) != null &&
            !list.ElementAt(i).Kind.HasValue);
    }
    public class SomeClass
    {
        public int? Kind { get; set; }
        public string Name { get; set; }
    }
