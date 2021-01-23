    private static void Main()
    {
        List<Int64> listOfAbundantNumbers = new List<Int64>();
        HashSet<Int64> listOfSums = new HashSet<Int64>();
        long total = 0;
        for (int i = 1; i < 20162; i++)
        {
            if (isAbundandt(i))
            {
                listOfAbundantNumbers.Add(i);
            }
            total += i;
        }
        for (int i = 0; i < listOfAbundantNumbers.Count; i++)
            for (int a = 0; a <= i; a++)
            {
                long temp1 = Convert.ToInt64(listOfAbundantNumbers[i]);
                long temp2 = Convert.ToInt64(listOfAbundantNumbers[a]);
                long num = temp1 + temp2;
                listOfSums.Add(num);
            }
        for (int i = 1; i < listOfAbundantNumbers.Count; i++)
        {
            long temp1 = Convert.ToInt64(listOfAbundantNumbers[i]);
            total -= temp1;
        }
        Console.WriteLine(total + "");
    }
    private static List<Int64> divisorList(long input)
    {
        List<Int64> divisors = new List<Int64>();
        for (long i = 2; i < Math.Round(Math.Sqrt(input), 0, 0); i++)
        {
            long temp = input % i;
            if (temp == 0)
            {
                divisors.Add(i);
                divisors.Add(input / i);
            }
        }
        return divisors;
    }
    private static Boolean isAbundandt(long input)
    {
        long sum = 0;
        List<Int64> divisor = divisorList(input);
        for (int i = 0; i < divisor.Count; i++)
        {
            long temp1 = divisor[i];
            sum += temp1;
        }
        sum++;
        if (sum > input)
        {
            return true;
        }
        return false;
    }
