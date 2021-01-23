    using System;
    namespace Exercise
    {
    class Permutations
    {
        static void Main(string[] args)
        {
            int setSize = 3;
            FindPermutations(setSize);
        }
        //-----------------------------------------------------------------------------
        /* Method: FindPermutations(n) */
        private static void FindPermutations(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }
            int iEnd = arr.Length - 1;
            Permute(arr, iEnd);
        }
        //-----------------------------------------------------------------------------  
        /* Method: Permute(arr) */
        private static void Permute(int[] arr, int iEnd)
        {
            if (iEnd == 0)
            {
                PrintArray(arr);
                return;
            }
            Permute(arr, iEnd - 1);
            for (int i = 0; i < iEnd; i++)
            {
                swap(ref arr[i], ref arr[iEnd]);
                Permute(arr, iEnd - 1);
                swap(ref arr[i], ref arr[iEnd]);
            }
        }
    }
    }
