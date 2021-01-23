    private static int[] Merge(int[] array1, int[] array2)
    {
      List<int> merged = new List<int>(array1.Length + array2.Length);
      merged.AddRange(array1);
      merged.AddRange(array2);
      return merged.GroupBy(x => x)
                   .Select(x => x.Key)
                   .OrderBy(x => x)
                   .ToArray();
    }
