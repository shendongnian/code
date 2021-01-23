    public static Task<string> DoWorkInSequence()
    {
        return (from x in Task_FromResult(5)
                where x != 5
                from y in Task_FromResult(true)
                where y
                select x.ToString() + y.ToString()
               ).IfCanceled("Nothing");
    }
