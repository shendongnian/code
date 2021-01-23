        public static bool UserIsInRole(WindowsIdentity identity, string group)
        {
            try
            {
                return new WindowsPrincipal(identity).IsInRole(group);
            }
            catch (Exception ex)
            {
                //Error checking role membership
                return false;
            }
        }
