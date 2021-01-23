        class Base
        {
        }
        interface I1
        {
        }
        interface I2
        {
        }
        class Derived : Base, I1, I2
        {
        }
        static void Main(String[] args)
        {
            Derived d = new Derived();
        }
