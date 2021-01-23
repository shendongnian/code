    public class Order
    {
        public string Customer;
        public List<OrderLine> OrderLines;
        public decimal Amount
        {
            get
            {
                if (this.OrderLines == null)
                    return 0;
                return this.OrderLines.Sum(o => o.Quantity * o.UnitPrice);
            }
        }
    }
