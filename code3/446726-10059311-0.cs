    public TValue RetryHelper<T, TValue>(Func<ObjectSet<T>, TValue> func)
        where T : class
    {
        using (MyEntities dataModel = new MyEntities())
        {
            var entitySet = dataModel.CreateObjectSet<T>();
            return FancyRetryLogic(() =>
                   {
                       return func(entitySet);
                   });
        }
    }
    public User GetUser(String userEmail)
    {
        return RetryHelper<User, User>(u => u.FirstOrDefault(x => x.UserEmail == userEmail));
    }
