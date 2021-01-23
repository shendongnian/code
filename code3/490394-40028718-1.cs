        //-----------------------------------------------------------------------------
        /*
            Method: PrintArray()
        */
        private static void PrintArray(int[] arr, string label = "")
        {
            Console.WriteLine(label);
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i < arr.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }
        //-----------------------------------------------------------------------------
        /*
            Method: swap(ref int a, ref int b)
        */
        private static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
