            static int[,] convert(int[] a, int size)
        {
            int[,] value = new int[a.Length / size, size];
            int counter = 0;
            //
            for (int b = 0; b < value.GetLength(0); b++)
                for (int c = 0; c < value.GetLength(1); c++)
                {
                     value[b, c] = a[counter];
                      counter++;
               }
            return value;
        }
