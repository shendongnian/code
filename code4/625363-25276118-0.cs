    public static int F(int[] array)
    {
        array = array.OrderByDescending(c => c).Distinct().ToArray();
        switch (array.Count())
        {
            case 0:
                return -1;
            case 1:
                return array[0];
        }
        return array[1];
    }
