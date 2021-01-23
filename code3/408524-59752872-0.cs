    public static void CopyToClipboard<T>(this IEnumerable<T> items)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (T item in items)
            stringBuilder.Append(item.ToString()).AppendLine();
        Clipboard.SetText(stringBuilder.ToString());
    }
