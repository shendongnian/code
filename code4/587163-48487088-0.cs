    static void Main(string[] args)
      {
        int[] array1 = { 1, 1, 1, 2, 3, 2, 2, 2, 2, 1 };
        int start = 0;
        int length  = 0;
        int bestStart = 0;
        int bestLength = int.MinValue;
        for (int i = 0; i < array1.Length - 1; i++)
            {
                if ((i == 0) || (array1[i] != array1[i - 1]))
                {
                    start = i;   
                }
                if(array1[start] == array1[start + 1])
                {
                    length++;
                    if (length > bestLength)
                    {
                        bestLength = length;
                        bestStart = start;
                    }         
                }
                else
                {
                    length = 0;
                }
            }
           Console.Write("The best sequence is :");
           for (int i = bestStart; i < bestLength + bestStart; i++)
            {
                Console.Write(" " + array1[i]);             
            }
     }
     /* 
         This will give : The best sequence is : 2 2 2 2 
    */
