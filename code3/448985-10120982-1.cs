    public static int ClosestTo(this IEnumerable<int> collection, int target)
    {
      // NB Method will return int.MaxValue for a sequence containing no elements.
      // Apply any defensive coding here as necessary.
      int closest = int.MaxValue;
      foreach (var element in collection) 
      {
        var difference = Math.Abs((long)element - target);
        if (closest > difference) 
        {
          closest = (int)difference;
        }
      }
      
      return closest;
    }
