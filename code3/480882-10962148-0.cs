    public bool IsDomainUser()
    {
      bool isDomain = false; 
      foreach (var grp in WindowsIdentity.GetCurrent().Groups)
      {
          if (grp.IsValidTargetType(typeof(SecurityIdentifier)))
          {
            SecurityIdentifier si = 
                    (SecurityIdentifier)grp.Translate(typeof(SecurityIdentifier));
            // not sure if this is right, but I'm not in a domain and don't have this SID
            // I do have LocalSID however, so you might need to turn it around,
            // if you have LocalSid you are not using a domain acount
            if (si.IsWellKnown(WellKnownSidType.BuiltinDomainSid))
            {
                isDomain = true;
            }
          }
       }
       return isDomain;
     }
  
       // for debugging list SIDS for current user and its groups
       foreach (var obj in Enum.GetValues(typeof(WellKnownSidType)))
       {
    
        if (WindowsIdentity.GetCurrent().User.IsWellKnown((WellKnownSidType)obj))
        {
            Debug.WriteLine("User:" + obj.ToString());
                        
        }
                    
        foreach (var grp in WindowsIdentity.GetCurrent().Groups)
        {
            if (grp.IsValidTargetType(typeof(SecurityIdentifier)))
            {
                SecurityIdentifier si = 
                     (SecurityIdentifier) grp.Translate(typeof(SecurityIdentifier));
                if (si.IsWellKnown((WellKnownSidType)obj))
                {
                    Debug.WriteLine("Grp: " + grp.ToString() + " : " + obj.ToString());
                }
            }
        }
      }
