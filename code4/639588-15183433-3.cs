    int[] column0 = new int[r.Length], column1 = new int[r.Length];
    
    for (int i = 0; i < r.Length; i++) // single loop over r
    {
        column0[i] = t[i].Column0;
        column1[i] = t[i].Column1;
    }
