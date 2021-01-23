    interface IReadOnly
    {
        int MyProperty { get; }
    }
    interface IModifiable : IReadOnly
    {
        int MyProperty { set; }
        void Save();
    }
