    private MyEnum myEnum = .... some value
    public MyEnum EnumProperty
    {
         get {return myEnum;} 
    
         set {
             if(value != myEnum)
             {
                 myEnum = value;
                 if(EnumPropertyChanged!=null)
                     EnumPropertyChanged(this, myEnum);
             }
         }   
    
    
    }
