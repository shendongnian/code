    private static List<string[]> DivideStrings(int expectedStringsPerArray, string[] allStrings)
    {
        List<string[]> arrays = new List<string[]>();
        int arrayCount = allStrings.Length / expectedStringsPerArray;
        int elemsRemaining = allStrings.Length;
        for (int arrsRemaining = arrayCount; arrsRemaining >= 1; arrsRemaining--)
        {
            int elementCount = elemsRemaining / arrsRemaining;
            string[] array = CopyPart(allStrings, elemsRemaining - elementCount, elementCount);
            arrays.Insert(0, array);
            elemsRemaining -= elementCount;
        }
        return arrays;
    }
