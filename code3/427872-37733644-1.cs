        //using System.Security.Principal
        //using System.DirectoryServices;
        public static void SetProtectADObject(DirectoryEntry ent, bool Protect = true)
        {
            //get parent object
            var parentEnt = new DirectoryEntry(ent.Parent.Path);
            //refresh objects
            ent.RefreshCache();
            parentEnt.RefreshCache();
            if (Protect)
            {
                #region Protect
                try
                {
                    IdentityReference everyOneAccount = new NTAccount("Everyone").Translate(typeof(SecurityIdentifier)); //S-1-1-0
                    var objAce = new ActiveDirectoryAccessRule(everyOneAccount, ActiveDirectoryRights.Delete | ActiveDirectoryRights.DeleteTree, AccessControlType.Deny);
                    var parentAce = new ActiveDirectoryAccessRule(everyOneAccount, ActiveDirectoryRights.DeleteChild, AccessControlType.Deny);
                    //check if ace present on object
                    var objACL = ent.ObjectSecurity;
                    bool acePresent = false;
                    foreach (ActiveDirectoryAccessRule ace in objACL.GetAccessRules(true, false, typeof(NTAccount)))
                    {
                        if (ace.IdentityReference.Value == "Everyone")
                        {
                            if (ace.ActiveDirectoryRights == (ActiveDirectoryRights.DeleteTree | ActiveDirectoryRights.Delete)) { acePresent = true; break; }
                        }
                    }
                    if (!acePresent)
                    {
                        //set ace to object
                        objACL.AddAccessRule(objAce);
                        //commit changes
                        ent.CommitChanges();
                    }
                    //check if ace present on parent object
                    var parentACL = parentEnt.ObjectSecurity;
                    bool parentAcePresent = false;
                    foreach (ActiveDirectoryAccessRule ace in parentACL.GetAccessRules(true, false, typeof(NTAccount)))
                    {
                        if (ace.IdentityReference.Value == "Everyone")
                        {
                            if (ace.ActiveDirectoryRights == (ActiveDirectoryRights.DeleteChild)) { parentAcePresent = true; break; }
                        }
                    }
                    if (!parentAcePresent)
                    {
                        //set ace to parent object
                        parentACL.AddAccessRule(parentAce);
                        //commit changes
                        parentEnt.CommitChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error protecting object {0}", ent.Path), ex);
                }
                #endregion
            }
            else
            {
                #region Unprotect
                //to remove the protection we remove only the ACE from the object, not from the parent. 
                //The ACE on the parent must be in place because otherwise other objects on the same level will not protected anymore!
                try
                {
                    IdentityReference everyOneAccount = new NTAccount("Everyone").Translate(typeof(SecurityIdentifier)); //S - 1 - 1 - 0
                    var objAce = new ActiveDirectoryAccessRule(everyOneAccount, ActiveDirectoryRights.Delete | ActiveDirectoryRights.DeleteTree, AccessControlType.Deny);
                    //check if ace present on object
                    var objACL = ent.ObjectSecurity;
                    bool acePresent = false;
                    foreach (ActiveDirectoryAccessRule ace in objACL.GetAccessRules(true, false, typeof(NTAccount)))
                    {
                        if (ace.IdentityReference.Value == "Everyone")
                        {
                            if (ace.ActiveDirectoryRights == (ActiveDirectoryRights.DeleteTree | ActiveDirectoryRights.Delete)) { acePresent = true; break; }
                        }
                    }
                    //set ace to object
                    if (acePresent)
                    {
                        ent.ObjectSecurity.RemoveAccessRule(objAce);
                        ent.CommitChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error unprotecting object {0}", ent.Path), ex);
                }
                #endregion 
            }
        }
        public static bool IsADObjectProtected(DirectoryEntry ent)
        {
            //get parent object
            var parentEnt = new DirectoryEntry(ent.Parent.Path);
            //refresh objects
            ent.RefreshCache();
            parentEnt.RefreshCache();
            //get current ACLs
            ActiveDirectorySecurity acl = ent.ObjectSecurity;
            ActiveDirectorySecurity parentAcl = ent.Parent.ObjectSecurity;
            AuthorizationRuleCollection rules = acl.GetAccessRules(true, true, typeof(NTAccount));
            AuthorizationRuleCollection parentRules = parentAcl.GetAccessRules(true, false, typeof(NTAccount));
            //check object acl
            bool acePresent = false;
            foreach (ActiveDirectoryAccessRule ace in rules)
            {
                Console.WriteLine(ace.AccessControlType.ToString());
                if (ace.AccessControlType == AccessControlType.Deny)
                {
                    if (ace.ActiveDirectoryRights == (ActiveDirectoryRights.DeleteTree | ActiveDirectoryRights.Delete)) { acePresent = true; break; }
                }
            }
            //check parent acl
            bool parentAcePresent = false;
            foreach (ActiveDirectoryAccessRule ace in parentRules)
            {
                if (ace.AccessControlType == AccessControlType.Deny)
                {
                    if (ace.ActiveDirectoryRights == (ActiveDirectoryRights.DeleteChild)) { parentAcePresent = true; break; }
                    else if (ace.ActiveDirectoryRights == (ActiveDirectoryRights.DeleteChild | ActiveDirectoryRights.DeleteTree | ActiveDirectoryRights.Delete)) { parentAcePresent = true; break; }
                }
            }
            return parentAcePresent && acePresent;
        }
