    using System;
    namespace Cloning
    {
        class Program
        {
            static void Main(string[] args)
            {
                Derived d = new Derived() { property = 1, field = 2, derivedProperty = 3, derivedField = 4 };
                Base b = new Derived(d);
                // Change things in the derived class.
                d.property = 5;
                d.field = 6;
                d.derivedProperty = 7;
                d.derivedField = 8;
                // Output the copy so you know it's not shallow.
                Console.WriteLine((b as Derived).property);
                Console.WriteLine((b as Derived).field);
                Console.WriteLine((b as Derived).derivedProperty);
                Console.WriteLine((b as Derived).derivedField);
                Console.ReadLine();
            }
            class Base
            {
                public int property { get; set; }
                public int field;
            }
            class Derived : Base
            {
                public Derived() { }
                public Derived(Derived d)
                {
                    // Perform the deep copy here.
                    // Using reflection should work, but explicitly stating them definitely
                    // will, and it's not like it's not all known until runtime.
                    this.property = d.property;
                    this.field = d.field;
                    this.derivedProperty = d.derivedProperty;
                    this.derivedField = d.derivedField;
                }
                public int derivedProperty { get; set; }
                public int derivedField;
            }
        }
    }
