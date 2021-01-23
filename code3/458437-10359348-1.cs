    var list = new[] { 2, 4, 7, 8 };
    List<int> lastConsecutive = new List<int>();
    for (int i = list.Length - 1; i > 0; i--)
    {
        lastConsecutive.Add(list[i]);
        if (list[i] - 1 != list[i - 1])
            break;
        if(i==1 && list[i] - 1 == list[i - 1]) // needed since we're iterating just until 1
            lastConsecutive.Add(list[0]);
    }
    lastConsecutive.Reverse();
