    public static void DoWhile(this IEnumerable<Action> actions,Func<bool> predicate)
    {
        foreach (var action in actions)
        {
            if (!predicate())
                return;
            actions();
        }
    }
