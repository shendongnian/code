    class Program
        {
            static void Main(string[] args)
            {
                int i, j;
                int[] unsortedarrayed = new int[] { 34, 36, 2, 7, 8, 3, 6, 5 };
    
                for (i = 0; i < unsortedarrayed.Length; i++)
                {
                    Console.WriteLine(unsortedarrayed[i]);
                }
                int[] sortedarray = InsertionSorted(unsortedarrayed);
    
                for (i = 0; i < sortedarray.Length; i++)    
                {
                    Console.WriteLine(sortedarray[i]);
                }
    
                Console.Read();
            }
    
            public static int[] InsertionSorted(int[] unsortedarrayed)
            {
                for (int i = 1; i < unsortedarrayed.Length; i++)
                {
                    int temp = unsortedarrayed[i];
                    int j = i - 1;
    
                    while ((j > -1) && (unsortedarrayed[j] > temp))
                    {
                        int tempo = unsortedarrayed[j + 1];
                        unsortedarrayed[j + 1] = unsortedarrayed[j];
                        unsortedarrayed[j] = tempo;
    
                        j = j - 1;
                    }
                }
    
                return unsortedarrayed;
            }
        }
