    public int AverageOfArray (params int[] arr)
    {
    
        double avg = 0;
    
        if (arr.Length > 0)
        {
            for (int n = 0; n < arr.Length; n++)
            {
                avg += arr[n]/arr.Length;
            }
    
        }
        return (int)avg;
    }
