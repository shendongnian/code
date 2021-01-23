     public int DoSomething(string input1, string input2)
     {
         // First simple case
         if (input1 == null || input2 == null)
         {
             return -1;
         }
         // Second simple case
         int totalLength = input1.Length + input2.Length;
         if (totalLength < 10)
         {
             return totalLength;
         }
         // Imagine lots of lines here, using input1, input2 and totalLength
         // ...
         return someComplicatedResult;
     }
