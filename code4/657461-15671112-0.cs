        private bool IsUserInDomain()
        {
            var prefix = WindowsIdentity.GetCurrent().Name.Split('\\')[0].ToUpperInvariant();
            if (prefix != Environment.MachineName.ToUpperInvariant())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
