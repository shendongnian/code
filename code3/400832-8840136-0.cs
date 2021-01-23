    [RunInstaller(true)]
    public class InstallRegistry : Installer
    {
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"software\..."))
            {
                RegistrySecurity rs = new RegistrySecurity();
                rs.AddAccessRule(new RegistryAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null), RegistryRights.FullControl, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
                key.SetAccessControl(rs);
            }
        }
        public override void Rollback(System.Collections.IDictionary savedState)
        {
            base.Rollback(savedState);
        }
    }
