    int[] arr = new int[] { 1, -1, -1, 1 };
            int[] new_arr = new int[4];
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                // Console.WriteLine(arr[i]);
                if (arr[i] == -1)
                    continue;
                else
                    new_arr[index++] = arr[i];
            }
            for (int i = 0; i < new_arr.Length; i++)
            {
                Console.WriteLine(new_arr[i]);
            }
