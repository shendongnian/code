            Console.Read();
        }
        class BaseClass<T> where T : BaseClass<T>
        {
            public static string WhatClassAmI = "BaseClass";
        }
        class Derived1 : BaseClass<Derived1>
        {
        }
        class Derived2 : BaseClass<Derived2>
        {
        }
    }
