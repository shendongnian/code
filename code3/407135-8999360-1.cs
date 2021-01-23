        public static IEnumerable<T> Flatten<T>(this T[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            for (var i = 0; i < rows;i++ )
            {
                for (var j = 0; j < cols; j++ )
                    yield return matrix[i, j];
            }
        }
