    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    
    namespace StockQuoteExample.DataModel
    {
        public class StockQuote : INotifyPropertyChanged
        {
    
            private string _ticker;
    
            public string Ticker
            {
                get { return _ticker; }
                set
                {
                    if (value != _ticker)
                    {
                        _ticker = value;
                        OnPropertyChanged("Ticker");
                    }
                }
            }
    
            private string _stockName;
    
            public string StockName
            {
                get { return _stockName; }
                set
                {
                    if (value != _stockName)
                    {
                        _stockName = value;
                        OnPropertyChanged("StockName");
                    }
                }
            }
    
            private decimal _tickPrice;
    
            public decimal TickPrice
            {
                get { return _tickPrice; }
                set
                {
                    if (value != _tickPrice)
                    {
                        _tickPrice = value;
                        OnPropertyChanged("TickPrice");
                    }
                }
            }
        
    
    
    
            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
