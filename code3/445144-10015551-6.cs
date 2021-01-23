    interface IReadOnly
    {
        int MyProperty { get; }
    }
    interface IModifiable : IReadOnly
    {
        new int MyProperty { set; }
        void Save();
    }
