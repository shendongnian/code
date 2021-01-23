    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public static bool operator ==(string a, string b)
    {
        return Equals(a, b);
    }
 
