    public class A
    {
        public virtual string SomeMethod()
        {
            return "A";
        }
    }
    
    public class B : A
    {
        public override string SomeMethod()
        {
            return "B";
        }
    }
    
    public class C : B
    {
        public virtual string AnotherMethod()
        {
            return "C";
        }
    }
    
    public class D : C
    {
        public override string AnotherMethod()
        {
            return "D";
        }
    }
    
    private void Test()
    {
        A a = new D();
        B b = new D();
        C c = new D();
        D d = new D();
        Console.WriteLine(a.SomeMethod()); //The method in class B is being called
        Console.WriteLine(b.SomeMethod()); //The method in class B is being called
        Console.WriteLine(c.AnotherMethod()); //The method in class D is being called
        Console.WriteLine(d.AnotherMethod()); //The method in class D is being called
    }
