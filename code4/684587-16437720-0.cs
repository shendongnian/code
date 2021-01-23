    public void Test()
    {
        ActionContext context = null; // Set it to null beforehand
        context = Create(delegate
        {
            context.Variable = 10;
        });
        context.Action.Invoke();
    }
