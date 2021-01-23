    public static class DelayedAction
    {
        private static Dictionary<Action, Tuple<DateTime, TimeSpan>> _actions;
        static DelayedAction()
        {
            _actions = new Dictionary<Action, Tuple<DateTime, TimeSpan>>();
        }
        public static void Add(Action a, TimeSpan executionInterval)
        {
            lock (_actions)
            {
                _actions.Add(a, new Tuple<DateTime, TimeSpan>(DateTime.MinValue, executionInterval));
            }
        }
        public static void ExecuteIfNeeded(Action a)
        {
            lock (_actions)
            {
                Tuple<DateTime, TimeSpan> t = _actions[a];
                if (DateTime.Now - t.Item1 > t.Item2)
                {
                    _actions[a] = new Tuple<DateTime, TimeSpan>(DateTime.Now, t.Item2);
                    a();
                }
            }
        }
    }
