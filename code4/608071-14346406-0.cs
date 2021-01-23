    public class MyEntity() 
    {
        public ValueType Prop1 { get; set; }
        public ValueType Prop2 { get; set; }
        // And so on...
        public MyEntity() 
        {
            Id = Guid.NewGuid();
        }
    }
