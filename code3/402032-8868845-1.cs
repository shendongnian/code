    private DateTime _price;
    public DateTime Price
    {
       get
       {
         return _price;
       }
       set
       {
         if(_price!=value)
         {
           _price = value;
           RaisePropertyChanged("Price");
         }
       }
    }
    protected void RaisePropertyChanged(string property)
    {
       var propertyChanged = PropertyChanged;
       if(propertyChanged!=null)
       {
         propertyChanged(this,new PropertyChangedEventArgs(property));
    
       }
    }
    
