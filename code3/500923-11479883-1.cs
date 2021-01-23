    class test
    {
       public string sam { get; set; }
       public string notsam {get; set; }
    }
    
    void Main()
    {
       var z = new test { sam = "sam", notsam = "alex" };
       
       z.Dump();
     
       z.GetPropertyByString("notsam").Dump();
  
       z.SetPropertyByString("sam","john");
       
       z.Dump();
    }
    
    static class Nice
    {
      public static void  SetPropertyByString(this object x, string p,object value) 
      {
         x.GetType().GetProperty(p).SetValue(x,value,null);
      }
      
      public static object GetPropertyByString(this object x,string p)
      {
         return x.GetType().GetProperty(p).GetValue(x,null);
      }
    }
