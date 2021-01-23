    class ReadOnlyClass : IReadOnly
    {
        public int MyProperty { get; private set; }
    }
    class ModifiableClass : IModifiable
    {
        public int MyProperty { get; set; }
        public void Save()
        {
            ...
        }
    }
