    static string MySpecialFunction(IEnumerable<string> input, int maxCount)
    {
        var items = input.ToArray();
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
