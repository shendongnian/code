    double[,] result = new double[list.Count, 2];
    for (int i = 0; i < list.Count; i++)
    {
        result[i, 0] = list[i][0];
        result[i, 1] = list[i][1];
    }
