    interface IStrategy<T> where T : IContext
    {
        T Context { get; }
    
        void Execute();
    }
    
    // this cab have other structures too depending on your common logic
    // like being generic
    interface IContext
    {
    }
