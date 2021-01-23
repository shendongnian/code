    ...
    if(input1 != null && input2 != null){
        output = DoSomething(input1, input2);
    }
    ...
    
    public int DoSomething(string input1, string input2)
    {
        int len = input1.Length + input2.Length;
        return len < 10 ? len : someComplecatedTask(input1, input2);
    }
    
    private int someComplicatedTask(string input1, string input2){
        // Imagine lots of lines here, using input1, input2
        // ...
        return someComplicatedResult;
    }
