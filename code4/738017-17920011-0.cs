    RegistryKey LocalMachine = Registry.LocalMachine;
             RegistryKey rk = LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\AMC",
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.ChangePermissions | RegistryRights.ReadKey);//Get the registry key desired with ChangePermissions Rights.
             RegistrySecurity rs = new RegistrySecurity();
             rs.AddAccessRule(new RegistryAccessRule("Administrator", RegistryRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));//Create access rule giving full control to the Administrator user.
             rk.SetAccessControl(rs); //Apply the new access rule to this Registry Key.
             rk = LocalMachine.OpenSubKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\AMC",
                RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl); // Opens the key again with full control.
             rs.SetOwner(new NTAccount("Administrator"));// Set the securities owner to be Administrator
             rk.SetAccessControl(rs);
             int MyNumber = 0; // Your value, doesn't have to be a number
             rk.SetValue("username", MyNumber);// The username should by the dynamic part
