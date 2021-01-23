    class mytype 
    {
      public static List<mytype> classinstance = new List<mytype>();
      public mytype()
      {
        classinstance.Add(this);
      }
    
      public removeclass(mytype t)
      {
        classinstance.Remove(t);
        t=null;
      }
      
      public int ActiveCount 
      {
        get { classinstance.Count; }
      }
    }
