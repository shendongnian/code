    List<string> dices = new List<string>();
    for (int i = 1; i <= 6; i++)
    {
        for (int j = i; j <= 6; j++)
        {
            for (int k = j; k <= 6; k++)
            {
                dices.Add(string.Format("{0} {1} {2}", i, j, k));
            }
        }
    }
