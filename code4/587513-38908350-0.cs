        /// <summary>
        /// Returns max value
        /// </summary>
        /// <param name="arr">array to search in</param>
        /// <param name="index">index of the max value</param>
        /// <returns>max value</returns>
        public static int MaxAt(int[] arr, out int index)
        {
            index = -1;
            int max = Int32.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                { 
                    max = arr[i];
                    index = i;
                }
            }
            return max;
        }
