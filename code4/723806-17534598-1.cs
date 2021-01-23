    class ComparableLockingObject
    {
        static int LastOrderValue = 0;
        private orderValue = LastOrderValue++;
     
        public bool Less(ComparableLockingObject other)
        {
           return this.orderValue < other.orderValue;
        }
    }
    static void foo(ComparableLockingObject o1, ComparableLockingObject o2,
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
