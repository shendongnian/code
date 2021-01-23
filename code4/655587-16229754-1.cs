    using System;
    
    interface IGeneric<T> {}
    
    class SomeClass
    {    
        public static void SomeMethod<T>(Func<IGeneric<T>> d) {}
    }
    
    class Concrete: IGeneric<object> {}
    
    class Test
    {
        static void Main()
        {
            var d = default(Func<Concrete>);
            // This compiles fine
            SomeClass.SomeMethod(d);
        }
    }
