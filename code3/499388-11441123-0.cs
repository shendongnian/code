    private static int[] Merge(int[] array1, int[] array2)
    {
      int[] newArray = new int[array1.Length + array2.Length];
      Array.Copy(array1, 0, newArray);
      Array.Copy(array2, 0, newArray, array1.Length, array2.Length);
      return newArray.GroupBy(x => x)
                     .Select(x => x.Key)
                     .OrderBy(x => x)
                     .ToArray();
    }
