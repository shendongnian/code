    public class Order : ICloneable
    {
        public int ID { get; set; }
        public object Clone()
        {
            return new Order { ID = ID };
        }
    }
