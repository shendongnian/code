    public static   int g = 0;
    public static void FillRow2(Object obj, out int val, out int index)
    {
        val = (int.Parse((string) obj)*2);
        int h = g;
       index = h++;
    }
