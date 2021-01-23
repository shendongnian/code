    public static class Ext
    {
        public static IEnumerable<IEnumerable<T>> Rotate<T>(
            this IEnumerable<IEnumerable<T>> src)
        {
            var matrix = src.Select(subset => subset.ToArray()).ToArray();
            var height = matrix.Length;
            var width = matrix.Max(arr => arr.Length);
            
            T[][] transpose = Enumerable
                .Range(0, width)
                .Select(_ => new T[height]).ToArray();
            for(int i=0; i<height; i++)
            {        
                for(int j=0; j<width; j++)
                {            
                    transpose[j][i] = matrix[i][j];            
                }
            }
     
            return transpose;
        }
    }
