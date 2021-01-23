    namespace {yourrootnamespace}
    {
    namespace GlobalMethods
    {
    static class ConsoleMethods
    {
    mainConsole mc;
    public static WriteLine(string msg, object sender)
    {
    lock (this)
    {
    mainConsole.WriteLine(msg, sender)
    }
    }
    static ConsoleMethods()
    {
    mc = new mainConsole();
    }
    //more methods
    }
    }
    }
