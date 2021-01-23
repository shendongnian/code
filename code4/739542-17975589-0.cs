    struct
    State
    {
        public string someField;
    }
    class
    ImmutableBox<T>
    {
        public readonly State state;
        ImmutableBox(State state)
        {
            this.state = state;
        }
    }
    void
    func1(ImmutableBox<State> passImmutableStateWithBox)
    {
    }
