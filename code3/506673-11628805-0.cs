    public IDisposable User()
    {
        YourDataContext context = new YourDataContext();
        Type ct = context.User.GetType();
        return (IDisposable)(ct);
    }
