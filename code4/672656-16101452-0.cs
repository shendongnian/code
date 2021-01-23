    public void DoProcessing()
    {
        LogCall();
    }
    public void LogCall([CallerMemberName] string memberName = "")
    {
         Console.WriteLine(memberName + " was called.");
    }
