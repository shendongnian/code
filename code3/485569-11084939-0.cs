    public static void Do(this TransactionScope scope, Action action) {
      using (scope) {
        action();
        scope.Complete();
      }
    }
