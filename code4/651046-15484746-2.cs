    private static int CompareValues(string x, string y)
    {
        if (x == null)
        {
            return y == null ? 0 : 1;
        }
        else
        {
           if (y == null)
                return 1;
           else
           {
                int retval = x.Length.CompareTo(y.Length)
                return retval != 0 ? retval : x.CompareTo(y);
               
           }
        }
     }
