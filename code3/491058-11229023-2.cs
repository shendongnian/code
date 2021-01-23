    public static bool SubListAddsTo(this IEnumerable<decimal> source,
      decimal target, decimal tolerance)
    {
      decimal lowtarget = target - tolerance;
      decimal hightarget = target + tolerance;
      HashSet<decimal> sums = new HashSet<decimal>();
      sums.Add(0m);
      List<decimal> newSums = new List<decimal>();
      foreach(decimal item in source)
      {
        foreach(decimal oldSum in sums)
        {
          decimal sum = oldSum + item;
          if (sum < lowtarget)
          {
            newSums.Add(sum);//keep trying
          }
          else if (sum < hightarget)
          {
            return true;
          }
          //else { do nothing, discard }
        }
        foreach (decimal newSum in newSums)
        {
          sums.Add(newSum);
        }
        newSums.Clear();
      }
      return false;
    }
