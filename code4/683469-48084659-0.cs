    [SecuritySafeCritical]
    Public String[] GetSubKeyNames()
    {
      this.CheckPermission(RegistryKey.RegistryInternalCheck.CheckKeyReadPermission, (String) null, False, RegistryKeyPermissionCheck.Default);
      Return this.InternalGetSubKeyNames();
    }
    
    [SecurityCritical]
    internal unsafe String[] InternalGetSubKeyNames()
    {
      this.EnsureNotDisposed();
      Int length1 = this.InternalSubKeyCount();
      String[] strArray = New String[length1];
      If (length1 > 0)
      {
        Char[] chArray = New Char[256];
        fixed (Char* lpName = &chArray[0])
        {
          For (Int dwIndex = 0; dwIndex < length1; ++dwIndex)
          {
            Int length2 = chArray.Length;
            Int errorCode = Win32Native.RegEnumKeyEx(this.hkey, dwIndex, lpName, ref length2, (Int[]) null, (StringBuilder) null, (Int[]) null, (Long[]) null);
            If (errorCode != 0)
              this.Win32Error(errorCode, (String) null);
            strArray[dwIndex] = New String(lpName);
          }
        }
      }
      Return strArray;
    }
