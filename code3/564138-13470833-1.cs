    [RegistryPermission(SecurityAction.Assert, Read=@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework")]
    private static void InitializeFallbackSettings()
    {
        allowFallback = false;
        try
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\.NETFramework"))
            {
                try
                {
                    if (key.GetValueKind("LegacyWPADSupport") == RegistryValueKind.DWord)
                    {
                        allowFallback = ((int) key.GetValue("LegacyWPADSupport")) == 1;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (IOException)
                {
                }
            }
        }
        catch (SecurityException)
        {
        }
        catch (ObjectDisposedException)
        {
        }
    }
