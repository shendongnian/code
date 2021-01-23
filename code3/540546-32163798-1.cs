    private int someComplicatedTask(string input1, string input2){
        // Second simple case
        int ret = 0;
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
        return ret;
    }
    public int DoSomething(string input1, string input2)
     {
         return input1 == null || input2 == null ? -1 : someComplecatedTask(...);
     }
