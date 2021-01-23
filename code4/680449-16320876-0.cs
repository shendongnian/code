    public object Invoke(object instance, object[] inputs, out object[] outputs)
    {
        using (log4net.ThreadContext.Stacks[key].Push(value))
        {
            return this.originalInvoker.Invoke(instance, inputs, out outputs);
        }
    }
