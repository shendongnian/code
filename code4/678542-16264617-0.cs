    if (result1.Length <= result2.Length)
    {
        for(int i = 0; i < Math.Min(result1.Length, result2.Length); i++)
        {
            for(int j = 0; j < Math.Min(result1[i].Length, result2[i].Length); j++)
            {
                if (result1[i,j] == result2[i,j])
                {
                    score++;
                }
            }
        }
    }
