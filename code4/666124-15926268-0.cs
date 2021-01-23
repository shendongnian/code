            string path = @"SOFTWARE\Microsoft\NET Framework Setup\NDP";
            List<string> display_framwork_name = new List<string>();
            RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(path);
            string[] version_names = installed_versions.GetSubKeyNames();
            for (int i = 1; i <= version_names.Length - 1; i++)
            {
                string temp_name = "Microsoft .NET Framework " + version_names[i].ToString() + "  SP" + installed_versions.OpenSubKey(version_names[i]).GetValue("SP");
                display_framwork_name.Add(temp_name);
            }
            return display_framwork_name;
