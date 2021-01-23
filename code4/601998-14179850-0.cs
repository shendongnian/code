    abstract class Base
    {
    }
    class Derived : Base
    {
    }
    class SuperDerived : Derived
    {
    }
    class Foo
    {
        static T GetItem<T>() where T : Base
        {
            return new Derived();
        }
        static void Bar()
        {
            var result = GetItem<SuperDerived>();
        }
    }
