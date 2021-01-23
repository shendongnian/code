     if (!SecurityManager.IsGranted(new DnsPermission(PermissionState.Unrestricted)))
            {
                //do something.... not at full trust
                try
                {
                    RegistryKey reg = Registry.ClassesRoot;
                    reg = reg.OpenSubKey(extension, false);
                    if (reg != null) contentType = (string)reg.GetValue("", def);
                }
                catch (Exception)
                {
                    contentType = def;
                }
            }
