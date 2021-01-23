    public interface IExceptional<TValue>
    {
        bool IsException();    
        TValue Value();
    }
