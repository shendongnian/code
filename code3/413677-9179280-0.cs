    public static void ShiftZerosRight(this int[] arr)
    {
        int j = 0;
        while (j < arr.Length && arr[j] != 0)
        {
            j++;
        }
        for (int i = j; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[j++] = arr[i];
            }
        }
        while (j < arr.Length)
        {
            arr[j++] = 0;    
        }
    }
