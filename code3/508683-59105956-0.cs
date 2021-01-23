public static class ArrayExtensions
{
    public static void Fill(this Array array, object value)
    {
        var indicies = new int[array.Rank];
        Fill(array, 0, indicies, value);
    }
    public static void Fill(Array array, int dimension, int[] indicies, object value)
    {
        if (dimension < array.Rank)
        {
            for (int i = array.GetLowerBound(dimension); i <= array.GetUpperBound(dimension); i++)
            {
                indicies[dimension] = i;
                Fill(array, dimension + 1, indicies, value);
            }
        }
        else
            array.SetValue(value, indicies);
    }
}
