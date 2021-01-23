    using System.Threading;
    public static AutoResetEvent arEvent = new AutoResetEvent(false);
    static void Main()
    {
        DoWork();
        arEvent.WaitOne();  //WaitOne() "pauses" Main and waits for some work to be done.
        DoWork();
        arEvent.WaitOne();
    }
    static void DoWork();
    {
        //Some work is done here.
        arEvent.Set(); //This lets Main() continue where it left off.
    }
