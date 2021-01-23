    private static readonly DateParsers = new Func<string,Tuple<DateTime,bool>>[] {
        (s) => {
            long res;
            if (long.TryParse(s, out res)) {
                // The format was correct - make a DateTime,
                // and return true to indicate a successful parse
                return Tuple.Create(new DateTime(res), true);
            } else {
                // It does not matter what you put in the Item1
                // when Item2 of the tuple is set to false
                return Tuple.Create(DateTime.MinValue, false);
            }
        }
        ...
        // Add similar delegates for other formats here
    };
