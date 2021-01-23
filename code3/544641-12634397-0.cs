        /// Checks if we have permission to delete a registry key
        /// </summary>
        /// <param name="key">Registry key</param>
        /// <returns>True if we can delete it</returns>
        public static bool CanDeleteKey(RegistryKey key)
        {
            try
            {
                if (key.SubKeyCount > 0)
                {
                    bool ret = false;
                    foreach (string subKey in key.GetSubKeyNames())
                    {
                        ret = CanDeleteKey(key.OpenSubKey(subKey));
                        if (!ret)
                            break;
                    }
                    return ret;
                }
                else
                {
                    System.Security.AccessControl.RegistrySecurity regSecurity = key.GetAccessControl();
                    foreach (System.Security.AccessControl.AuthorizationRule rule in regSecurity.GetAccessRules(true, false, typeof(System.Security.Principal.NTAccount)))
                    {
                        if ((System.Security.AccessControl.RegistryRights.Delete & ((System.Security.AccessControl.RegistryAccessRule)(rule)).RegistryRights) != System.Security.AccessControl.RegistryRights.Delete)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            catch (SecurityException)
            {
                return false;
            }
        }
