    public static bool IsSorted(int[] arr)
    {
    int l = arr.Length;
    for (int i = 1; i < l/2 + 1 ; i++)
    {
        if (arr[i - 1] > arr[i] || arr[l-i] < arr[l-i-1])
        {
        return false;
        }
    }
    return true;
    }
