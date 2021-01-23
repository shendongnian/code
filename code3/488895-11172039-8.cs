    public void StockUpdated(object sender, MyEventArgs eventArgs)
    {
        OrderBook book = (OrderBook) sender;
        //Here use book.ListIndex to access the original list element.
    }
