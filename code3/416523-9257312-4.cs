    public static class MyParallel
    {
        public static void While(Func<bool> condition, Action action)
        {
            Parallel.ForEach(WhileTrue(condition), _ => action());
        }
        static IEnumerable<bool> WhileTrue(Func<bool> condition)
        {
            while (condition()) yield return true;
        }
    }
