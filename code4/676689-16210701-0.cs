    private int _footerText;
    public int FooterText
    {
       get
       {
          return this._footerText;
       }
       set
       {  
          this._footerText = value;
          NotifyPropertyChanged("FooterText");
       }
    }
