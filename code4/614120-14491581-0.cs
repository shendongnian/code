    static class Program
    {
        static void Main()
        {
            Base baseObject = new Derived();
            Derived derivedObject = new Derived();
            Console.Write(derivedObject.Test());
            Console.Write(baseObject.Test());
            Console.Write(((Base)derivedObject).Test());
        }
    }
    class Base
    {
        public virtual int Test()
        {
            return 1;
        }
    }
    class Derived : Base
    {
        public new int Test()
        {
            return 2;
        }
    }
