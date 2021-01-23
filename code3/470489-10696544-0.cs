    foreach (var x in GetSomething())
    {
         if (someCondition) break;
    }
    public IEnumerable<int> GetSomething()
    {
        List<int> list = new List<int>() { 1, 2, 3 };
        int index=0;
        while (true)
            yield return list[index++ % list.Count];
    }
