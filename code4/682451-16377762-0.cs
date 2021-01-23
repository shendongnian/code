    using System;
     
    public class Test
    {
            public static void Main()
            {
                    var c = new C();
                    c.MethodOne();
            }
    }
     
    public class A
    {
        public virtual void MethodOne()
        {
           Console.WriteLine( "A" ); 
        }
    }
     
    public class B : A
    {
        public override void MethodOne()
        {
            base.MethodOne();
            Console.WriteLine( "B" );
        }
    }
     
    public class C : B
    {
        public override void MethodOne()
        {
            base.MethodOne();
            Console.WriteLine( "C" );
        }
    }
