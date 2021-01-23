    public static class Memoizer
    {
        public static Func<T, TR> Do<T, TR>(Func<T, TR> gen)
        {
            var mem = new Dictionary<T, TR>();
            return (target) =>
            {
                if (mem.ContainsKey(target))
                    return mem[target];
                mem.Add(target, gen(target));
                return mem[target];
            };
        }
    }
