    if (!Context.GetTable<T>().IsAttached(value))
    {
        Context.GetTable<T>().Attach(value);
    }
    Context.Refresh(RefreshMode.KeepCurrentValues, value);
    Context.SubmitChanges();
