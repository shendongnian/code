    public void WriteLog(Func<string> s)
    {
        if (needToWriteLog)
        {
            Console.WriteLine(s);
        }
    }
