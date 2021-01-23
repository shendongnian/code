    private static void StuffDone(IAsyncResult ar)
    {
        Action r = ar.AsyncState as Action;
        r.EndInvoke(ar);
        Console.WriteLine(DateTime.Now.ToLocalTime().ToLongTimeString() + " - Stuff done");
    }
