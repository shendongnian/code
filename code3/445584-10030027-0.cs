    public static void Main(string[] args)
    {
        int i = 0;
        var t = new Thread(() =>
        {
            try
            {
            }
            finally
            {
                while (true) i++;
            }
        });
        t.Start();
        Thread.Sleep(1000);
        t.Abort(); // this blocks indefinitely!
        Console.WriteLine("aborted"); // never gets here!
    }
