    class Program
    {
        static void Main(string[] args)
        {
            Derived1.WhatClassAmI = "Derived1";
            Derived2.WhatClassAmI = "Derived2";
    
            Console.WriteLine(Derived1.WhatClassAmI); // "Derived1"
            Console.WriteLine(Derived2.WhatClassAmI); // "Derived2"
    
            Console.WriteLine(BaseClass<Derived1>.WhatClassAmI); // "Derived1"
            Console.WriteLine(BaseClass<Derived2>.WhatClassAmI); // "Derived2"
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
