    public string Index()
    {
        return GetType().FullName + GetMemberName();
    }
    static string GetMemberName([CallerMemberName] string memberName = "")
    {
        return memberName;
    }
