    class
    ImmutableBox<T> where T : struct, new()
    {
        public readonly T state;
        ImmutableBox(T state)
        {
            this.state = state;
        }
    }
    
    struct
    ExampleStateA
    {
        public string someField;
    }
    
    void
    func1(ImmutableBox<ExampleStateA> passImmutableStateWithBox)
    {
    }
    
