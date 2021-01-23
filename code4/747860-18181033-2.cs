    public static void ShiftLeft<T>(List<T> lst, int shifts)
    {
        for (int i = shifts; i < lst.Count; i++)
        {
            lst[i - shifts] = lst[i];
        }
        for (int i = lst.Count - shifts; i < lst.Count; i++)
        {
            lst[i] = default(T);
        }
    }
