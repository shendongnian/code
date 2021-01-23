    // C# PInvoke declaration for needed IE method.
    [DllImport("ieframe.dll")]
    public static extern int IEGetWriteableHKCU(ref IntPtr phKey); 
    // ...
            // somewhere inside other method:
            IntPtr phKey = new IntPtr();
            var answer = IEGetWriteableHKCU(ref phKey);
            RegistryKey writeable_registry = RegistryKey.FromHandle(
                new Microsoft.Win32.SafeHandles.SafeRegistryHandle(phKey, true)
            );
            RegistryKey registryKey = writeable_registry.OpenSubKey(RegistryPathString, true);
            if (registryKey == null) {
                registryKey = writeable_registry.CreateSubKey(RegistryPathString);
            }
            registryKey.SetValue("Mode", mode);
            writeable_registry.Close();
