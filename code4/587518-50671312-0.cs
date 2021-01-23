            int[] arr = new int[] {35,28,20,89,63,45,12};
            int big = 0;
            int little = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
                if (arr[i] > arr[0])
                {
                    big = arr[i];
                }
                else
                {
                    little = arr[i];
                }
            }
            Console.WriteLine("most big number inside of array is " + big);
            Console.WriteLine("most little number inside of array is " + little);  
