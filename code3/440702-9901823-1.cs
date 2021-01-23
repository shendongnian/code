    class SourceType
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    class DestinationType
    {
        public string CustName { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var source = new SourceType()
            {
                Name = "Test",
                Number = 22
            };
            var destination = new DestinationType();
            source.MapTo(destination, (src, dst) => dst.CustName == src.Name && dst.Age == src.Number);
            bool assert = source.Name == destination.CustName && source.Number == destination.Age;
        }
    }
