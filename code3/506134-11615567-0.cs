    EventHandler _priceChanged; 
    public event EventHandler PriceChanged
    {
    add { _priceChanged += value; }
    remove { _priceChanged -= value; }
    }
