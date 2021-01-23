    interface IDevice<TDevice>
       where TDevice : InternalDevice1
    {
       TDevice Device { get; }
    }
