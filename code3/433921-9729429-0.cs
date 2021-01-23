    public class foo
    {
        private object lockObject = new object();
        public int bar
        {
            get
            {
                 lock(lockObject){
                    return 42;
                 }
             }
         }
         public int aMethod()
         {
             lock(lockObject)
             {
                 var a = this.bar;
                 return a*2;   //insert a break point here
              }
          }
    }
