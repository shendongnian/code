    int[] array = new int[4];
    List<int> list = new List<int>(4);
    List<int, int> dictionary1 = new Dictionary<int, int>(4);
    List<string, int> dictionary2 = new Dictionary<string, int>(4);
    for(int x = 0; x < 4; x++)
    {
        array[x] = bar;
        list[x] = bar;
        dictionary1.Add(x, bar);
        dictionary2.Add("foo" + x.ToString(), bar);
    }
