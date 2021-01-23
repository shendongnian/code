    public item()
    {      
      this.PropertyChanged += new PropertyChangedEventHandler(AnyPropertyChanged); 
    }
    
    private void AnyPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      // example how to use
      if (e.PropertyName == "anyproperyname")
      {
           
      }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    public void InvokePropertyChanged(PropertyChangedEventArgs e)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) handler(this, e);
    }
    
    private Boolean bTheProperty = true;
    public Boolean TheProperty
    {
       get { return bTheProperty ; }
       set 
       { 
         if (bTheProperty != value) 
         { 
           bTheProperty = value; 
           InvokePropertyChanged(new PropertyChangedEventArgs("TheProperty")); 
         }           
       }
    }
