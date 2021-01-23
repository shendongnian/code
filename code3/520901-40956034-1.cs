     public static bool IsSorted(int[] arr, int index)
        {
            if (index >= arr.Length - 1)
            {
                return true;
            }
            else if ((arr[index] <= arr[ index + 1]) && IsSorted(arr, index + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
