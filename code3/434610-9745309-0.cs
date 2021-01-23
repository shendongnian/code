    public class A : IDisposable
    {
        private readonly EventHandler handler;
    
        public A()
        {
            handler = (sender, e) =>
            {
               Line 1
               Line 2
               Line 3
               Line 4
            };
            B_Object.DataLoaded += handler;
         }
    
         public override void Dispose()
         {
            B_Object.DataLoaded -= handler;
         }
    }
