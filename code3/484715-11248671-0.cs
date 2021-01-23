    public inteface ITool<T>
    {
       int ToolIndex { get; }
       string Category { get; }
       Action OnClick(T eventArgs);
    }
