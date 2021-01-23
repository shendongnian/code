    [Flags]
    public enum Permissions
    {
        ViewListItems = 1 << 0,
        ...
        UseClientIntegration = 1 << 9
    }
    static bool CheckMask(Permissions mask, Permissions testPermission)
    {
        return (mask & testPermission) != 0;
    }
