    interface IFoo {
        Int32 Id { get; }
    }
    interface IMutableFoo: IFoo {
        void SetId(Int32 value);
    }
