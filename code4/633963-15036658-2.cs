    public class A
    {
        public string OrderNumber { get; private set; }
        public A()
        {
            OrderNumber = "ORD" + get_next_id() + DateTime.Now.Year;
        }
    }
