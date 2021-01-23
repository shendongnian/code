    public static void AbsAll(this List<float> list)
    {
      for (int i = 0; i < list.Count; ++i)
        list[i] = Math.Abs(list[i]);
    }
