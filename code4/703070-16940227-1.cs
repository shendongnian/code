    Apps = (from a in key.GetSubKeyNames()
                    let r = key.OpenSubKey(a)
                    select new
                    {
                        DisplayName = r.GetValue("DisplayName"),
                        RegistryKey = r.GetValue("UninstallString")
                    })
                .Distinct()
                .OrderBy(c => c.DisplayName)
                .Where(c => c.DisplayName != null && c.RegistryKey != null)
                .ToDictionary(k => k.RegistryKey.ToString(), v => v.DisplayName.ToString());
