    class BusinessLayer
    {
        public void Update(Type data)
        {
            OrderBook.Update(data);
            NasdaqIndex.Update(OrderBook);
            NasdaqStrategy.Update(NasdaqIndex);
        }
    }
