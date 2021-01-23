    public class Stock
    {
        string symbol;
        decimal price;
        // constructor
        public Stock (string symbol) { this.symbol = symbol; }
        public event EventHandler PriceChanged;
        protected virtual void OnPriceChanged
        {
            if (PriceChanged != null) PriceChanged(this, e);
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                price = value;
                OnPriceChanged(EventArgs.Empty);
            }
        }
    }
