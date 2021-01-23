    public static void ShiftRight<T>(List<T> lst, int shifts)
    {
        for (int i = lst.Count - shifts - 1; i >= 0; i--)
        {
            lst[i + shifts] = lst[i];
        }
        for (int i = 0; i < shifts; i++)
        {
            lst[i] = default(T);
        }
    }
