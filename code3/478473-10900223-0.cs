    [Test]
    public void TestSwap()
    {
        int[] myArray = { 1, 2, 3, 4 };
        Console.WriteLine(string.Join(", ", myArray));
        Swap(myArray, 1, 2);
        Swap(myArray, 2, 3);
        Console.WriteLine(string.Join(", ", myArray));
    }
    static void Swap(int[] vals, int x, int y)
    {
        vals[x] = vals[x] ^ vals[y];
        vals[y] = vals[y] ^ vals[x];
        vals[x] = vals[x] ^ vals[y];
    }
