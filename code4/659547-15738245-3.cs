     public CurrenciesEnum Ccy
     {
        get { return this._ccy; }
        set
        { 
            if (value != this._ccy) 
            {
                this._ccy = value;
                
                //This is the code you need to implement
                
                    this.MyDataGridItems
                        .Where(item=> item== this.SelectedDataGridRow)
                        .First()
                        .MyColumn = value;
                NotifyPropertyChanged("Ccy");
            }
        }
    }
