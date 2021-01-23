    public class MyClassA
    {
        protected bool test;
        public MyClassA()
        {
            //Do the work
            if (true)
            {
                test = true;
                return;
            }
        }
    }
    public class MyClassB : MyClassA
    {
        public MyClassB() 
        {
            if (base.test)
            {
                //How to catch exception from a constructor in MyClassA?
            }
           
        }
    }
