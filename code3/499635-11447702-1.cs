    public void PushFoo(Action bar1, Action bar2)
    {
        IFoo foo = new ActionableFoo(bar1, bar2);
        _fooStack.Push(foo);
    }
