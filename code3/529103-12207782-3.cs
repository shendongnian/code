    public void SomeFunc(Action<bool,int> foo)
    {
        bool param1 = true;
        int param2 = 69;
        foo(param1, param2); // Here you are calling the foo delegate.
    }
