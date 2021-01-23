    public static T[,] GetColumns<T>(IList<IEnumerable<T>> source, int numColumns)
    {
        T[,] output = new T[source.Count, numColumns];
    
        for (int i = 0; i < source.Count; i++)
        {
            int j = 0;
            foreach (T item in source[j].Take(numColumns))
            {
                output[i, j] = item;
                j++;
            }
        }
    
        return output;
    }
