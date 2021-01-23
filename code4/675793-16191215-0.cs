    public interface IMinimalState<T>
    {
        T generate();
        int getData();
    }
    public interface IState : IMinimalState<IState>
    {
        IState generate();
        int getAnotherData();
    }
