    private string m_AccountName;
    public event PropertyChangedEventHandler PropertyChanged;
    public string AccountName
    {
       get { return m_AccountName;}
       set 
         { 
            m_AccountName = value;
            OnPropertyChanged("AccountName");
         }
    }
    protected void OnPropertyChanged(string name)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
          handler(this, new PropertyChangedEventArgs(name));
      }
    }
  
       //NEW
       public override string ToString()
       {
           return AccountName;
       }
    }
