    public static class EnumerableStateExt
    {
        public static bool AllStatesSet(this IEnumerable<State> self, params State[] states)
        {
            bool[] results = new bool[states.Length];
            foreach (var item in self)
            {
                for (int i = 0; i < states.Length; ++i)
                    if (item == states[i])
                        results[i] = true;
                if (results.All(state => state))
                    return true;
            }
            return false;
        }
    }
