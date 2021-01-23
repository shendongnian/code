    private Dictionary<string, int> _guidHash = 
         new Dictionary<string, int>();
    private Dictionary<string, int> _nameHash = 
         new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    
    public int GetHashCode(ISyncableUser obj)
    {
        int hash = 0;
    
        if (obj==null) return hash;
    
        if (!String.IsNullOrWhiteSpace(obj.Guid) 
            && _guidHash.TryGetValue(obj.Guid, out hash))
            return hash;
    
        if (!String.IsNullOrWhiteSpace(obj.UserPrincipalName) 
            && _nameHash.TryGetValue(obj.UserPrincipalName, out hash))
            return hash;
    
        hash = RuntimeHelpers.GetHashCode(obj); 
        // or use some other method to generate an unique hashcode here
    
        if (!String.IsNullOrWhiteSpace(obj.Guid)) 
             _guidHash.Add(obj.Guid, hash);
    
        if (!String.IsNullOrWhiteSpace(obj.UserPrincipalName)) 
             _nameHash.Add(obj.UserPrincipalName, hash);
    
        return hash;
    }
