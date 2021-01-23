    double[] input = double[5]; //Pretend the user has entered these
    int[] counters = int[input.Length]; //One for each "dimension"
    List<double> sums = new List<double>();
    for (int i = 0; i < counters.Length; i++)
       counters[i] = -1; //The -1 value allows the process to begin with sum of single digits, then pairs, etc..
    while (true)
    {
        double thisSum = 0;
        //Apply counters
        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i] == -1) continue; 
            thisSum += input[counters[i]];
        }
        //Increment counters
        counters[0]++; //Increment at base
        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i] >= counters.Length)
            {
                if (i == counters.Length - 1) //Check if this is the last dimension
                   return sums; //Exhausted all possible combinations
                counters[i] = 0;
                counters[i+1]++;
            }
            else
               break;
        }
    }
