    public static Array CreateArray(Array array)
    {
        // Gets the lengths and lower bounds of the input array
        int[] lowerBounds = new int[array.Rank];
        int[] lengths = new int[array.Rank];
        for (int numDimension = 0; numDimension < array.Rank; numDimension++)
        {
            lowerBounds[numDimension] = array.GetLowerBound(numDimension);
            lengths[numDimension] = array.GetLength(numDimension);
        }
        Type elementType = array.GetType().GetElementType();  // Gets the type of the elements in the input array
        return Array.CreateInstance(elementType, lengths, lowerBounds);    // Returns the new array
    }
