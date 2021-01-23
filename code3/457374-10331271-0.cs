    private MyEnum myEnum = .... some value
    public MyEnum EnumProperty
    {
         get {return myEnum;} 
    
         set {
             if(value != myEnum)
             {
                 myEnum = value;
                 if(EnumPorpertyChanged!=null)
                     EnumPorpertyChanged(this, myEnum);
             }
         }   
    
    
    }
