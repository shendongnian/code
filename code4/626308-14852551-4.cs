    public interface INode
    {
        bool IsReadOnly { get; }
        void DoSomething();
        void DoSomethingWith(INode it);
    }
