    static List<int> GetDeepestPossibility(List<int> values, int sum = 0)
    {
      List<int> deepest = new List<int>();
      for (int i = 0; i < values.Count; i++)
      {
        if (Allowed(values[i] + sum))
        {
          List<int> subValues = new List<int>(values);
          subValues.RemoveAt(i);
          List<int> possibility = GetDeepestPossibility(subValues, values[i] + sum);
          possibility.Add(values[i]);
          if (possibility.Count + 1 > deepest.Count)
          {
            possibility.Add(values[i]);
            deepest = possibility;
            if (deepest.Count == values.Count - 1)
              break;
          }
        }
      }
      return deepest;
    }
    private static bool Allowed(int p)
    {
      return p >= 0 && p <= 600;
    }
