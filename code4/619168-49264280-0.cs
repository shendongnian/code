    public static class MonoOptionsExtensions
    {
        public static List<string> ParseStrict(this OptionSet source, IEnumerable<string> arguments)
        {
            var args = arguments.ToArray();
            var beforeDoubleDash = args.TakeWhile(x => x != "--");
            var unprocessed = source.Parse(beforeDoubleDash);
            var firstUnprocessedOpt = unprocessed.Find(x => x.Length > 0 && (x[0] == '-' || x[0] == '/'));
            if (firstUnprocessedOpt != null)
                throw new OptionException("Unregistered option '" + firstUnprocessedOpt + "' encountered.", firstUnprocessedOpt);
            return unprocessed.Concat(args.SkipWhile(x => x != "--").Skip(1)).ToList();
        }
    }
