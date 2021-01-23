    public T CreateAndAdd<T>() where T : Control, new()
    {
        T newControl = new T();
        Controls.Add(newControl);
        return newControl;
    }
