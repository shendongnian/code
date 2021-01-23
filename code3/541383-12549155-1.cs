    enum ePermissions
    {
       None = 0,
       View = 1,
       Edit = 2,
       Delete = 4,
       Add = 8,
       All = 15
    }
    
    ePermissions t;
    t = (ePermissions)((add?ePermissions.Add:ePermissions.None) | (delete?ePermissions.Delete:ePermissions.None) | ...);
