    private static void DoAction(params Expression<Action<Group>>[] actions)
    {
        foreach (var action in actions)
        {
            var method = action.Body as MethodCallExpression;
            if(method != null)
                Console.WriteLine(method.Method.Name);
        }
    }
