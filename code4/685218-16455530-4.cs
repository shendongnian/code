            public IEnumerable<int> FindIndexes(int[] array, int value)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int Tempval = array[i];
                    if (Tempval == value)
                    {
                        yield return i;
                    }
                }
            }
