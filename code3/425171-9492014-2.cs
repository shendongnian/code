            RegistryKey myKey = Registry.LocalMachine.OpenSubKey( @"Software\RSA", false);
            String value = (String)myKey.GetValue("WebExControlManagerPth");
            if (!String.IsNullOrEmpty(value))
            {
                ProcessAsUser.Launch(ToString());
            }
