    public static void DoPermute(ref byte[] digits, ref int n, ref int i)
    {
        List<long> permuts = new List<long>();
        DoPermuteWorker(permuts, ref digits, ref n, ref i);
        return permuts;
    }
    public static void DoPermuteWorker(List<long> permuts, ref byte[] digits, ref int n, ref int i)
    {
        if (i == n)
        {
            long temp = Numbers.JoinDigits(digits);
            permuts.Add(temp);
        }
        else
        {
            for (int j = i; j < n; j++)
            {
                SwapValues(ref digits, ref i, ref j);
                int temp = i + 1;
                DoPermuteWorker(permuts, ref digits, ref n, ref temp);
                SwapValues(ref digits, ref i, ref j);
            }
        }
    }
