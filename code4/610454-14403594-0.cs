    private SubCoded _codec;
    internal SubCodec Codec 
    {
          get {return _codec;}  
          set 
          {
                _codec = value;
                OnPropertyChanged("Codec");
           }
     }
