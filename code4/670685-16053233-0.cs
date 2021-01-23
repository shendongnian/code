    static void Implicit()
    {
        Log();
    }
    static void Explicit()
    {
        Log("Explicit");
    }
    static void Log([CallerMemberNameAttribute] string name = null)
    {}
