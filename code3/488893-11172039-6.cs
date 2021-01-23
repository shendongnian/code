    public class OrderBookManager
    {
        private List<OrderBook> list = new List<OrderBook>();
        public void Add(OrderBook book)
        {
            list.Add(book);
            book.ListIndex = list.Count - 1;
            // Assign Owner here if that is needed.
        }
        // Make this read-only if you want to ensure the manager controls all updates to the list (better design) but use it this way for higher performance.
        public List<OrderBook> List { get { return list; } }
    }
