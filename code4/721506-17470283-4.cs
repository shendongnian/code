    private list oParent
    
    public item(list parent)
    {
      this.oParent = parent;
    }
    
    private string sName;
    public string Name
    {
       get { return sName; }
       set 
       { 
         if (sName!= value) 
         { 
           sName= value; 
           if(this.parent != null)
           {  
             this.parent.IsSorted = false; 
           }
         }           
       }
    }
