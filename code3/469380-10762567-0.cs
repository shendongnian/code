    static IEnumerable<int[]> Permutation(int[] bounds)
    {
      for(int num0s = bounds.Length; num0s >= 0; --num0s)
      {
        foreach(int[] ret in PermHelper(num0s, 0, bounds, new int[bounds.Length]))
          yield return ret;
      }
    }
    static IEnumerable<int[]> PermHelper(int num0s, int index, int[] bounds, int[] result)
    {
      //Last index.
      if(index == bounds.Length - 1)
      {
        if(num0s > 0)
        {
          result[index] = 0;
          yield return result;
        }
        else
        {
          for(int i = 1; i < bounds[index]; ++i)
          {
            result[index] = i;
            yield return result;
          }
        }
      }
      //Others.
      else
      {
        //still need more 0s.
        if(num0s > 0)
        {
          result[index] = 0;
          foreach(int[] perm in PermHelper(num0s - 1, index + 1, bounds, result))
            yield return perm;
        }
        //Make sure there are enough 0s left if this one isn't a 0.
        if(num0s < bounds.Length - index)
        {
          for(int i = 1; i < bounds[index]; ++i)
          {
            result[index] = i;
            foreach(int[] perm in PermHelper(num0s, index + 1, bounds, result))
              yield return perm;
          }
        }
      }
    }
