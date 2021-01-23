    public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {           
            var result = new List<List<T>>();
            for (int i = 0; i < source.Count; i += chunkSize)
            {
                var rows = new List<T>();
                for (int j = i; j < i + chunkSize; j++)
                {
                    if (j >= source.Count) break;
                    rows.Add(source[j]);
                }
                result.Add(rows);
            }
            return result;
        }
