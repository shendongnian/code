    if (result1.Length <= result2.Length)
    {
        for(int i = 0; i < result1.Length; i++)
        {
            for(int j = 0; j < result2.Length; j++)
            {
                if (result1[i,0] == result2[j,0] && result1[i,1] == result2[j,1])
                {
                    score++;
                }
            }
        }
    }
