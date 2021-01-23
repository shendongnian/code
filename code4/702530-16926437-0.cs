    public void Invoke<T>(Func<T> func){
        return (T) InvokeInternal(func);
    }
    public void Invoke(Action action){
        InvokeInternal(action);
    }
