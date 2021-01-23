    partial class Foo
    {
        partial void Method();
        Foo()
        {
            Action action = new Action(Method);
        }
    }
