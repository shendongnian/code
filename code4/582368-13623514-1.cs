    private void Foo(MyClass cl)
    {
        if (cl is MyClass2)
        {
            Test((MyClass2)cl);
        }
        else
        {
            Test(cl);
        }
    }
    private void Test(MyClass cl)
    {
        // Behaviour for MyClass
    }
    private void Test(MyClass2 cl2)
    {
        // Behaviour for MyClass2
    }
