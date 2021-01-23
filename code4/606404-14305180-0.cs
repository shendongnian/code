    /*
    Write a program that reads an array of integers and removes from it a minimal number of elements in such way that the
    remaining array is sorted in increasing order. Print the remaining sorted array.
    Example: {6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}
     */
    using System;
    using System.Collections.Generic;
    
    class RemoveMinimalElements
    {
        static bool CheckAscending(List<int> list)
        {
            bool ascending = true;
    
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    ascending = false;
                }
            }
    
            return ascending;
        }
            
        static void Main()
        {
            int n;
            n = int.Parse(Console.ReadLine());
            List<int> arr = new List<int>();
            List<int> sorted = new List<int>();
            int maxSubsetLenght = 0;
    
            for (int i = 0; i < n; i++)
            {
                arr.Add(int.Parse(Console.ReadLine()));
            }
    
    
            for (int i = 1; i <= (int)Math.Pow(2, n) - 1; i++)
            {
                int tempSubsetLenght = 0;
                List<int> temp = new List<int>();
    
    
                for (int j = 1; j <= n; j++)
                {
                    if (((i >> (j - 1)) & 1) == 1)
                    {
                        temp.Add(arr[j - 1]);
                        tempSubsetLenght++;
                    }
                   
                }
    
                if ((tempSubsetLenght > maxSubsetLenght) && (CheckAscending(temp)))
                {
                    sorted = temp;
                    maxSubsetLenght = tempSubsetLenght;
                }
            }
    
            for (int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine(sorted[i]);
            }
        }
    }
