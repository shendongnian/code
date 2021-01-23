    public static void FirstDouble(int[] array)
    {
        //double each elements value
        for (int i = 0; i < array.Length; i++)
            array[i] *= 2;
        //create new object and assign its reference to array
        array = new int[] { 11, 12, 13 };
    }
