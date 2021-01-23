    class Program
    {
        static void Main(string[] args)
        {
            Derived1.WhatClassAmI = "Derived1";
            Derived2.WhatClassAmI = "Derived2";
            Console.WriteLine(Derived1.WhatClassAmI); // "Derived1"
            Console.WriteLine(Derived2.WhatClassAmI); // "Derived2"
