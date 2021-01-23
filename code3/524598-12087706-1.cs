    public static T Extract<T>(this List<T> list, int index)
    {
        var item = list[index];
        list.RemoveAt(index);
        return item;
    }
