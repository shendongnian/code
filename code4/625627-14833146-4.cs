    public static string SendData(int i)
    {
        // sample payload
        Thread.Sleep(i);
        return i.ToString();
    }
    public static IAsyncResult BeginSendData(int i, AsyncCallback cb)
    {
        var f = new Func<int, string>(SendData);
        return f.BeginInvoke(i, cb, f);
    }
    public static string EndSendData(IAsyncResult ar)
    {
        return ((Func<int, string>)ar.AsyncState).EndInvoke(ar);
    }
    static void Main(string[] args)
    {
        BeginSendData(2000, ar => 
            {
                var result = EndSendData(ar);
                Console.WriteLine("Done: {0}", result);
            });
        Console.WriteLine("Waiting");
        Console.ReadLine();
    }
