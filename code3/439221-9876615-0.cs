    private ShortQuote _selectedQuote;
    
    public ShortQuote SelectedQuote
    {    
         get { return _selectedQuote; }
         set
         {
              if(value != _selectedQuote)
              {
                   _selectedQuote = value;
                   RaisePropertyChanged("SelectedQuote");
              }
          }
    }
