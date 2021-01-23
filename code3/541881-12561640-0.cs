      using System.Runtime.InteropServices;
      using System.Runtime.InteropServices.ComTypes;
      var tiPtr = Marshal.GetITypeInfoForType(typeof (IMyInterface));
      var ti = (ITypeInfo)Marshal.GetObjectForIUnknown(tiPtr);
      string[] names = new string[1];
      int cnt;
      ti.GetNames(-4, names, 1, out cnt); // -4 = DISPID_NEWENUM
      // string[0] == "_NewEnum"
