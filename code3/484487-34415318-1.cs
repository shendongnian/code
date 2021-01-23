    bool hasDuplicate = false;
    int[] a = new int[] { 1, 2, 3, 4 };
    int[] b = new int[] { 5, 6, 1, 2, 7, 8 };
    for (int i = 0; i < a.Length; i++)
    {
        for (int j = 0; j < b.Length; j++)
        {
            if (a[i] == b[j])
            {
                hasDuplicate = true;
            }
        }
    }
