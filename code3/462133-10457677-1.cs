    class MyActions
    { 
        public delegate MyAction<T>();
    }
    public void Execute(MyActions.MyAction<T> action) 
    {
    ...
    }
