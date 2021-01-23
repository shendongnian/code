     class SaleItem : INotifyPropertyChanged
    {
        public int Num { get; set; }
        public string ItemID { get; set; }
        public string Name { get; set; }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                this.price = value; 
                OnPropertyChanged("Total");
            }
        }
        private decimal quantity;
        public decimal Quantity
        {
            get { return quantity; }
            set
            {
                this.quantity = value; 
                OnPropertyChanged("Total");
            }
        }
        public decimal Total
        {
            get { return Price * Quantity; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
