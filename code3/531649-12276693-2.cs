    public class MyClass
    {
        private static int count;
        private static object _lock = new object();
         
        public MyClass()
        {
             lock(_lock)
             {
                 count++;
             }
         }
        
        private ~MyClass()
        {
            lock(_lock)
            {
                 count--;
            }
        }
    }
