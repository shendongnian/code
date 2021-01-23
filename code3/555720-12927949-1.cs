    public string Index()
    {
        return GetMemberName(this);
    }
    static string GetMemberName(
        object caller, [CallerMemberName] string memberName = "")
    {
        return caller.GetType().FullName + "." + memberName;
    }
