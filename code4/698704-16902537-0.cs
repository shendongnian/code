    bool IsInRange(string text, int lower, int upper, params int[] diqualifiers)
    {
      int value = int.MinValue;
      if (!int.TryParse(text, out value)) {
        return false;
      }
      if (!(value >= lower && value <= upper)) {
        return false;
      }
      if (disqualifiers != null && disqualifiers.Any(d => d == value)) {
        return false;
      }
      return true;
    }
