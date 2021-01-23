        static IEnumerable<string> GetVariations(string s)
        {
            int[] indexes = new int[s.Length];
            StringBuilder sb = new StringBuilder();
            while (IncrementIndexes(indexes, s.Length))
            {
                sb.Clear();
                for (int i = 0; i < indexes.Length; i++)
                {
                    if (indexes[i] != 0)
                    {
                        sb.Append(s[indexes[i]-1]);
                    }
                }
                yield return sb.ToString();
            }
        }
        static bool IncrementIndexes(int[] indexes, int limit)
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i]++;
                if (indexes[i] > limit)
                {
                    indexes[i] = 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
