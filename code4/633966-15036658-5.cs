    public class A
    {
        public string OrderNumber { get; private set; }
        public A()
        {
            OrderNumber = "ORD" + get_next_id() + DateTime.Now.Year;
        }
    }
    // Somewhere else in your code
    A a = new A();
    string orderNumber = a.OrderNumber;
