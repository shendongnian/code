    using System;
    
    class ObjectParent
    {
        public virtual void Foo()
        {
            Console.WriteLine("ObjectParent.Foo");
        }
    }
    
    class ObjectChild : ObjectParent
    {
        public override void Foo()
        {
            Console.WriteLine("ObjectChild.Foo");
        }
    }
    
    class Test
    {
        static void Main()
        {
            // Simpler code to demonstrate the point
            ObjectParent parent = new ObjectChild();
            parent.Foo(); // Prints ObjectChild.Foo
        }
    }
