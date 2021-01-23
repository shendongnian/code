    int[] iArray = { 1, 2, 3, 2, 3, 4, 3 };
    int[] EachWords = { 1, 2, 3, 2, 3, 4, 3 };
    for (int p = 0; p < EachWords.Length; p++)
    {
        for (int j = 0; j < EachWords.Length; j++)
        {
            if (EachWords[p] == EachWords[j] && p != j)
            {
                List<int> tmp = new List<int>(EachWords);
                tmp.RemoveAt(j);
                EachWords = tmp.ToArray();
            }
        }
    }
    for (int j = 0; j < EachWords.Length; j++)
    {
        Response.Write(EachWords[j].ToString() + "\n");
    }
