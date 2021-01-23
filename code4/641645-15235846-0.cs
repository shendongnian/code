    public static void StupidSort<T>(T[] array)
                where T : IComparable<T>
    {
        int index = 0;
        while (index < array.Length)
        {
            if (index == 0 ||
				array[index - 1].CompareTo(array[index]) <= 0)
            {
                index++;
            }
            else
            {
                Swap(array, index - 1, index);
                index--;
            }
        }
    }
