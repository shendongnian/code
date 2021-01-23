    public class Source
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public decimal Amount { get; set; }
    }
    
    public class DestinationBase
    {
        public int Id { get; set; }
    }
    
    public class DestinationDerived1 : DestinationBase
    {
        public string Name { get; set; }
        public decimal Value2 { get; set; }
    }
    
    public class DestinationDerived2 : DestinationBase
    {
        public decimal Value { get; set; }
    }
