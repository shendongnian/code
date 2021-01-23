    public dClass(bClass c) 
    { 
    // copy base class properties. 
     foreach (PropertyInfo prop in c.GetType().GetProperties()) 
     {   
      PropertyInfo prop2 = c.GetType().GetProperty(prop.Name); 
      prop2.SetValue(this,prop.GetValue(c, null), null); 
     }  
    }
