     if (SecurityManager.IsGranted(new RegistryPermission(PermissionState.Unrestricted)))
            {
                try
                {
                    RegistryKey reg = Registry.ClassesRoot;
                    reg = reg.OpenSubKey(@"MIME\Database\Content Type\" + contentType, false);
                    if (reg != null) ext = (string)reg.GetValue("Extension", def);
                }
                catch (Exception)
                {
                    ext = def;
                }
            }
