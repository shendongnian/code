    public void DoWork(object param)
    {
        ThreadState state = param as ThreadState;
        if (state == null)
            throw InvalidCastException("Unable to cast type {0} to {1}.", param.GetType().Name, typeof(ThreadState).Name);
        state.SomeReturnValue = "Success";
    }
