    private int[] Shift(int[] a)
    {
        int zeroPos = Array.IndexOf(a, 0);
        int[] rtn = new int[a.Length];
        a.CopyTo(rtn, 0);
        if (zeroPos + 1 == a.Length)
        {
            rtn[0] = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                rtn[i + 1] = a[i];
            }
        }
        else
        {
            rtn[zeroPos] = rtn[zeroPos + 1];
            rtn[zeroPos + 1] = 0;
        }
        return rtn;
    }
