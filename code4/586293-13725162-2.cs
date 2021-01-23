    public IEnumerator<IEnumerable<T>> GetEnumerator()
    {
        int rows = DataMatrix.GetLength(0);
        int cols = DataMatrix.GetLength(1);
         for(int r = 0; r < rows; r++)
         {
            T[] row = new T[cols]();
    
            for(int c = 0; c < cols; c++)
            {
                row[c] = DataMatrix[r,c];
            }
            yield return row;
        }
    }
