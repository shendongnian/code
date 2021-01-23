    public static bool IsGuid(this string checkGuid)
    {
        if (string.IsNullOrEmpty(checkGuid)) return false;
        Guid resultGuid;
        return Guid.TryParse(checkGuid, out resultGuid);
    }
