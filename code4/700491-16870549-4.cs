    public class Order : ICloneable
    {
        public int ID { get; set; }
        public Order Clone()
        {
            return new Order { ID = ID };
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
    }
