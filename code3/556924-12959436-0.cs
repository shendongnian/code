    // For demonstration purposes only. Please don't use in real life.
    public static void Conditional(this bool result,
                                   Action trueAction,
                                   Action falseAction)
    {
        Action action = result ? trueAction : falseAction;
        action();
    }
