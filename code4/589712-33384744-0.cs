        int[] a= { 2, 5, 4, 8, 7, 3 };
        int temp;
        for (int i = 0; i < a.Length; i++) 
        {
            for (int j = 0; j <a.Length; j++) 
            {
                if (j != a.Length - 1)
                {
                    if (a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            
            }
        }
