    List<int> foo;
    int[] bar = foo.ToArray();
    foreach(int i in bar)
    {
        if (i == 2)
        {
            foo.Remove(i);
        }
    }
