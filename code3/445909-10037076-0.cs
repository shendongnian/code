    public static bool IsInRange(this double? input, Tuple<double, double> range)
    {
       if (!input.HasValue)
          return false;
       return input >= range.Item1 && input <= range.Item2;
    }
