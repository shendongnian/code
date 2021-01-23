    class MyActions
    { 
        public delegate MyAction<T>();
        public MyAction<T> FirstAction { get; private set; }
    }
    public void Execute(MyActions.MyAction<T> action) 
    {
    ...
    }
