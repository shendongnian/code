    if (!DataContext.GetTable<T>().IsAttached(value))
    {
        DataContext.GetTable<T>().Attach(value);
    }
    DataContext.Refresh(RefreshMode.KeepCurrentValues, value);
    DataContext.SubmitChanges();
