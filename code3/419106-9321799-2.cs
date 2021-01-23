    public static void Execute(Action<ITransactionScope> action)
    {
      using( var scope = TransactionManager.BeginTransaction() )
      {
        action(scope);
        scope.Commit();
      }
    }
    
    public static TResult Execute<TResult>(Func<ITransactionScope, TResult> func)
    {
      using( var scope = TransactionManager.BeginTransaction() )
      {
        var result = func(scope);
        scope.Commit();
        return result;
      }
    }
