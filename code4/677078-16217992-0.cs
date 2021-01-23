    public void PerformAction(MyViewModel vm, bool newVal,
        Action<MyViewModel, bool> action)
    {
        action(vm, newVal);
    }
    PerformAction(someViewModel, true, (vm, b) => vm.IsReadOnly = b);
