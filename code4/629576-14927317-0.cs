    public class Stock : INotifyPropertyChanged
    {
        private string _ticker;
        private StockData _priceData;
        private StockData _companyData;
        public string Ticker
        {
            get { return _ticker; }
            set { _ticker = value; NotifyPropertyChanged("Ticker"); }
        }
        public StockData PriceData
        {
            get { return _priceData; }
            set { _priceData = value; NotifyPropertyChanged("PriceData"); }
        }
       
        public StockData CompanyData
        {
            get { return _companyData; }
            set { _companyData = value; NotifyPropertyChanged("CompanyData"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
