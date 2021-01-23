    public class A
    {
        public A()
        {
            B b = new B
                      {
                          MyA = this
                      };
        }
    }
    public class B
    {
        public A MyA;
    }
