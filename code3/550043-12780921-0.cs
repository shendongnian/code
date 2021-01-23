    List<string> list = new List<string> { "abc", "abc", "ab", "def", "abc", "def" };
    list.Sort();
    int i = 0;
    while (i < list.Count - 1)
    {
        if (list[i] == list[i + 1])
            list.RemoveAt(i);
        else
            i++;
    }
