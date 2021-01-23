    public event Action<List<string>> MyEvent;
    private void Foo()
    {
         MyEvent(new List<string>(){"a", "b", "c"});
    }
