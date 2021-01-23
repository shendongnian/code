    public static void MoveItems<T>(List<T> list1, List<T> list2)
    {
        list2.AddRange(list1);
        list1.Clear();
    }
