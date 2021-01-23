    class ComparebleLockingObject
    {
        static int LastOrderValue = 0;
        private orderValue = LastOrderValue++;
     
        public bool Less(ComparebleLockingObject other)
        {
           return this.orderValue < other.orderValue;
        }
    }
    static void foo(ComparebleLockingObject o1, ComparebleLockingObject o2,
        Action action)
    {
       if (o2.Less(o1))
       {
          var temp = o1;
          o1 = o2;
          o2 = temp;
       }
   
       lock (o1)
       {
         lock (o2)
            {
               action();
            }
        }
    }
