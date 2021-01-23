    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
    public static extern int RegOpenCurrentUser(int samDesired, out IntPtr phkResult);    
    
    public enum RegistrySecurity
    {
        KEY_ALL_ACCESS = 0xF003F,
        KEY_CREATE_LINK = 0x0020,
        KEY_CREATE_SUB_KEY = 0x0004,
        KEY_ENUMERATE_SUB_KEYS = 0x0008,
        KEY_EXECUTE = 0x20019,
        KEY_NOTIFY = 0x0010,
        KEY_QUERY_VALUE = 0x0001,
        KEY_READ = 0x20019,
        KEY_SET_VALUE = 0x0002,
	KEY_WOW64_32KEY = 0x0200,
        KEY_WOW64_64KEY = 0x0100,
        KEY_WRITE = 0x20006,
    }
    public IntPtr GetImpersonateUserRegistryHandle(RegistrySecurity _access)
    {
        IntPtr safeHandle = new IntPtr();
        int result = RegOpenCurrentUser((int)_access, out safeHandle);
        return safeHandle;
    }
    /// <summary>
    /// Get a registry key from a pointer.
    /// </summary>
    /// <param name="hKey">Pointer to the registry key</param>
    /// <param name="writable">Whether or not the key is writable.</param>
    /// <param name="ownsHandle">Whether or not we own the handle.</param>
    /// <returns>Registry key pointed to by the given pointer.</returns>
    public RegistryKey _pointerToRegistryKey(IntPtr hKey, bool writable, bool ownsHandle)
    {
        //Get the BindingFlags for private contructors
        System.Reflection.BindingFlags privateConstructors = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        //Get the Type for the SafeRegistryHandle
        Type safeRegistryHandleType =
                typeof(Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid).Assembly.GetType("Microsoft.Win32.SafeHandles.SafeRegistryHandle");
        //Get the array of types matching the args of the ctor we want
        Type[] safeRegistryHandleCtorTypes = new Type[] { typeof(IntPtr), typeof(bool) };
        //Get the constructorinfo for our object
        System.Reflection.ConstructorInfo safeRegistryHandleCtorInfo = safeRegistryHandleType.GetConstructor(
                privateConstructors, null, safeRegistryHandleCtorTypes, null);
        //Invoke the constructor, getting us a SafeRegistryHandle
        Object safeHandle = safeRegistryHandleCtorInfo.Invoke(new Object[] { hKey, ownsHandle });
        //Get the type of a RegistryKey
        Type registryKeyType = typeof(RegistryKey);
        //Get the array of types matching the args of the ctor we want
        Type[] registryKeyConstructorTypes = new Type[] { safeRegistryHandleType, typeof(bool) };
        //Get the constructorinfo for our object
        System.Reflection.ConstructorInfo registryKeyCtorInfo = registryKeyType.GetConstructor(
                privateConstructors, null, registryKeyConstructorTypes, null);
        //Invoke the constructor, getting us a RegistryKey
        RegistryKey resultKey = (RegistryKey)registryKeyCtorInfo.Invoke(new Object[] { safeHandle, writable });
        //return the resulting key
        return resultKey;
    }
