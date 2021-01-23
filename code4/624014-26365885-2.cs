    public static void BubbleSort(int[] a)
        {
                     
           for (int i = 1; i <= a.Length - 1; ++i)
           
                for (int j = 0; j < a.Length - i; ++j)
               
                    if (a[j] > a[j + 1])
                   
                        Swap(ref a[j], ref a[j + 1]);
                                                                 
        }
        public static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
