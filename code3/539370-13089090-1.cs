    public string CombinationFinder()
    {
        for (int i = 0; i < 2 ^ 8; i++)
        {
            String ans = Convert.ToInt32(i, 2).ToString();
            if (myMethod(ans))
            {
                return ans;
            }
        }
        return null;
    }
