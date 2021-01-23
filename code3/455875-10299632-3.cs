    private string _idCode;
    
    public string IDCode
    {
     get{
          return _idCode;
        }
     set{
         _idCode = value;
         PropertyChanged("IDCode");
        }
    }
