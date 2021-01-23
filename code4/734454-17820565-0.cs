    public static Array CreateNewArrayOfSameSize(Array input)
    {
        int[] lengths = new int[input.Rank];
        for (int i = 0; i < lengths.Length; i++)
        {
            lengths[i] = input.GetLength(i);
        }
        return Array.CreateInstance(array.GetType().GetElementType(), lengths);
    }
