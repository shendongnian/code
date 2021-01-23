    using System;
    using Microsoft.Win32;
    using System.Runtime.InteropServices;
    public class MyClassThatNeedsToRegister
    {
       Guid categoryGuid = ...;
  
       [ComRegisterFunctionAttribute]
       public static void RegisterFunction(Type t)
       {
           RegistryKey key = Registry.ClassesRoot.CreateSubKey(
	     "CLSID\\" + t.GUID.ToString("B") + 
	     "\\Implemented Categories\\" + categoryGuid.ToString("B");
       }
   
       [ComUnregisterFunctionAttribute]
       public static void UnregisterFunction(Type t)
       {
          Registry.ClassesRoot.DeleteSubKey( "CLSID\\" + t.GUID.ToString("B") +
           "\\Implemented Categories\\" + categoryGuid.ToString("B"), false);
       }
    }
