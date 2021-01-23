    namespace RotatingMatrices
    {
        public static class RotateMatrix
        {
            static public void DebugPrintMatrix ( string[,] array )
            {
                for(int y = 0; y < array.GetLength(0); y++)
                {
                    for(int x = 0; x < array.GetLength(1); x++)
                    {
                        System.Diagnostics.Debug.Write(array[y, x] + " ");
                    }
                    System.Diagnostics.Debug.WriteLine("");
                }
            }
    
            static public string[,] RotateClockwiseSkipDiagonals ( string[,] matrix )
            {
                if(matrix == null || matrix.Rank != 2 || matrix.GetLength(0) != matrix.GetLength(1))
                {
                    throw new System.ArgumentException("matrix must be a non-null array of rank 2 which is square");
                }
                string[,] matrixCopy = matrix.Clone() as string[,];
                // start by rotating outermost ring
                return RotateClockwiseSkipDiagonalsRecurse(matrixCopy, 0, matrixCopy.GetLength(0));
            }
    
            static private string[,] RotateClockwiseSkipDiagonalsRecurse ( string[,] matrix, int start, int size )
            {
                if(size <= 2)
                {
                    return matrix;
                }
    
                string[] ring = new string[4 * (size - 2)];
    
                //first store current ring rotated by 1 in an array
                int counter = 0;
    
                // first element of new ring is last element of old ring
                ring[counter++] = matrix[start + 1, start];
    
                // top side of ring
                for(int i = start + 1; i < start + size - 1; i++)
                {
                    ring[counter++] = matrix[start, i];
                }
    
                // right side of ring
                for(int i = start + 1; i < start + size - 1; i++)
                {
                    ring[counter++] = matrix[i, start + size - 1];
                }
    
                // bottom side of ring
                for(int i = start + size - 2; i > start; i--)
                {
                    ring[counter++] = matrix[start + size - 1, i];
                }
    
                // left side of ring, except for last element
                for(int i = start + size - 2; i > start + 1; i--)
                {
                    ring[counter++] = matrix[i, start];
                }
    
                // now write back ring to matrix
                counter = 0;
    
                // top side of ring
                for(int i = start + 1; i < start + size - 1; i++)
                {
                    matrix[start, i] = ring[counter++];
                }
    
                // right side of ring
                for(int i = start + 1; i < start + size - 1; i++)
                {
                    matrix[i, start + size - 1] = ring[counter++];
                }
    
                // bottom side of ring
                for(int i = start + size - 2; i > start; i--)
                {
                    matrix[start + size - 1, i] = ring[counter++];
                }
    
                // left side of ring
                for(int i = start + size - 2; i > start; i--)
                {
                    matrix[i, start] = ring[counter++];
                }
    
                // rotate next ring inwards
                return RotateClockwiseSkipDiagonalsRecurse(matrix, start + 1, size - 2);
            }
        }
    }
