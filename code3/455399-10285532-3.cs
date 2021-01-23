    public bool GetSomeValueById(Guid innerId)
    {
        using (var a = SomeFactory.GetA(_uri))
        {
            return a.GetSomeValue();
        }
    }
    class A : IDisposable
    {
      private a;
      private b;
    
      public A (B b, C c)
      {
         this.b = b; this.c = c;
      }
    
      public void Dispose()
      {
         Dispose(true);
      }
    
      protected void Dispose(bool disposing)
      {
         if (disposing)
         {
            b.Dispose();
            c.Dispose();
         }
      }
    }
 
