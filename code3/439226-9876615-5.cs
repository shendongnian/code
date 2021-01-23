    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using StockQuoteExample.DataModel;
    
    namespace StockQuoteExample.ViewModel
    {
        class StockQuoteViewModel : INotifyPropertyChanged
        {
    
            public ObservableCollection<StockQuote> StockQuotes { get; set; }
    
            private StockQuote _selectedTicker;
    
            public StockQuote SelectedTicker
            {
                get { return _selectedTicker; }
                set
                {
                    if (value != _selectedTicker)
                    {
                        _selectedTicker = value;
                        OnPropertyChanged("SelectedTicker");
                    }
                }
            }
    
    
            public StockQuoteViewModel()
            {
                StockQuotes = new ObservableCollection<StockQuote>()
                                  {
                                      new StockQuote() {StockName = "Microsoft", TickPrice = 150m, Ticker = "MSFT"},
                                      new StockQuote() {StockName = "Apple", TickPrice = 600m, Ticker = "AAPL"}
                                  };
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
