    public int DoSomething(string input1, string input2)
     {
         int ret;
    
         // First simple case
         if (input1 == null || input2 == null)
         {
    
             ret = -1;
         }
         else
         {
             // Second simple case
             int totalLength = input1.Length + input2.Length;
             if (totalLength < 10)
             {
                 ret = totalLength;
             }
             else
             {
                 // Imagine lots of lines here, using input1, input2 and totalLength
                 // ...
                 ret = someComplicatedResult;
             }
         }
         return ret;
     }
