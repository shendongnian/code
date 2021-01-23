    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    
    namespace CsharpLibrary
    {
       // Since the .NET Framework interface and coclass have to behave as 
       // COM objects, we have to give them guids.
       [Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770"),
        InterfaceType(ComInterfaceType.InterfaceIsDual)]
       public interface IStringHolder
       {
          String GetText();
          void SetText(String s);
       }
    }
