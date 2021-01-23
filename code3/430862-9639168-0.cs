    /// <summary>
    /// Generates and prints next permutation lexicographically.
    /// </summary>
    /// <param name="a">An array representing a permutation.</param>
    /// <returns><c>true</c> if next permutation was generated succesfully, <c>false</c> otherwise.</returns>
    public bool PrintNextPermutation(int[] a)
    {
        int i = a.Length - 2;
        while (i >= 0 && a[i] >= a[i + 1]) i--;
        if (i <0)
        {
            // it was the last permutation
            return false;
        }
        int j = a.Length - 1;
        while (a[i] >= a[j]) j--;
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
        Array.Reverse(a, i + 1, a.Length - (i + 1));
        foreach (int item in a)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        return true;
    }
