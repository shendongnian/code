    namespace {yourrootnamespace}
    {
    namespace GlobalMethods
    {
    static class ConsoleMethods
    {
    public static WriteLine(string msg, object sender)
    {
    lock (this)
    {
    mainConsole.WriteLine(msg, sender)
    }
    }
    //more methods
    }
    }
    }
