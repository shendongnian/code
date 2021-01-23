    // ...
    string text2 = list[list.Count - 1];
    list.RemoveAt(list.Count - 1);
    if (text2.Length >= 248)
    {
        throw new PathTooLongException(Environment.GetResourceString("IO.PathTooLong"));
    }
    // ...
