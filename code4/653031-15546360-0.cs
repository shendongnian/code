    public IEnumerator<string> GetEnumerator()
    {
        StackTrace stackTrace = new StackTrace();
        Console.WriteLine(stackTrace.GetFrame(1).GetMethod().Name);
        return items.GetEnumerator();
    }
