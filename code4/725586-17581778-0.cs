    public double Average()
    {
        // smallest is initialized to a very large value.
        int smallest = int.MaxValue;
    
        // To calculate the average, we need to find the sum of all our temperatures,
        // except the smallest.
        int sum = 0;
        // The loop does two things:
        // 1. Adds all of the values.
        // 2. Determines the smallest value.
        for (int c = 0; c < temp.Length; ++c)
        {
            if (temp[c] < smallest)
            {
                smallest = temp[c];    
            }
            sum += temp[c];
        }
        // The computed sum includes all of the values.
        // Subtract the smallest.
        sum -= smallest;
        double avg = 0;
        // and divide by (Length - 1)
        // The check here makes sure that we don't divide by 0!
        if (temp.Length > 1)
        {
            avg = (double)sum/(temp.Length-1);
        }
       return avg;
    }
