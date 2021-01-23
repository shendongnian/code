    static class Nice
    {
      static void  SetPropertyByString(this object x, string p,object value) 
      {
         x.GetType().GetProperty(p).SetValue(x,value);
      }
      static object GetPropertyByString(this object x,string p)
      {
         return x.GetType().GetProperty(p).GetValue(x);
      }
    }
