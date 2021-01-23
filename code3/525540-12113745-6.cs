    public class Thing
    {
        public int Value1 { get; set; }
        public double Value2 { get; set; }
        public string Value3 { get; set; }
        // preferable to create own Equals and GetHashCode methods
        public Tuple<int, double>  GetKey()
        {
           // create key on fields you want 
           return Tuple.Create(Value1, Value2);
        }
    }
