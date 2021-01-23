    static string MySpecialFunction<T>(IEnumerable<T> input, Func<T, string> selector, int maxCount)
    {
        if (input == null)
            throw new ArgumentNullException("input");
        if (selector == null)
            throw new ArgumentNullException("selector");
        if (maxCount <= 0)
            throw new ArgumentOutOfRangeException("maxCount must be greater than 0.");
        var items = input.Select(selector).ToArray();
        if (items.Length < 1)
        {
            return string.Empty;
        }
        else if (items.Length == 1)
        {
            return items[0];
        }
        else
        {
             var joined = String.Join(", ", items, 0, Math.Min(items.Length, maxCount));
             if (items.Length > maxCount)
             {
                  joined += String.Format(", and {0} more.", items.Length - maxCount);
             }
             return joined;
        }
    }
