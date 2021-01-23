    public static class ArrayExtensions
        {
            public static void Set<T>(this Array array, T defaultValue)
            {
                int[] indicies = new int[array.Rank];
    
                SetDimension<T>(array, indicies, 0, defaultValue);
            }
    
            private static void SetDimension<T>(Array array, int[] indicies, int dimension, T defaultValue)
            {
                for (int i = 0; i <= array.GetUpperBound(dimension); i++)
                {
                    indicies[dimension] = i;
    
                    if (dimension < array.Rank - 1)
                        SetDimension<T>(array, indicies, dimension + 1, defaultValue);
                    else
                        array.SetValue(defaultValue, indicies);
                }
            }
        }
