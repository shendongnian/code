    private bool _isFooUpdating;
    private void SetFoo(string value)
    {
        _isFooUpdating = true;
        Foo = value;
        _isFooUpdating = false;
    }
    public string Foo
    {
        get { return _foo; }
        set
        {
            if (_foo = value) return;
            _foo = value;
            OnFooChanged();
            OnPropertyChanged("Foo");
        }
    }
    private void OnFooChanged()
    {
        if (_isFooUpdating) return;
        FooChangedCommand.Execute();
    }
