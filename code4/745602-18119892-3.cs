    public static string GetMethodName(Delegate del)
    {
        return del.Method.Name;
    }
    string str8 = GetMethodName((Action)Main);
    string str9 = GetMethodName((Func<int>)Method1);
    string str10 = GetMethodName((Func<int, int>)Method2);
