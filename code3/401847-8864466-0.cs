    public bool IsChecked
    {
       get
       {
           if(IntProperty == 0)
              return false;
           return true;
       }
       set
       {
           if(value)
              IntProperty = 1;
           else 
              IntProperty = 0;
       }
    }
