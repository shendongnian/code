    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
 
    namespace DotNetLibrary
    {
      [ClassInterface(ClassInterfaceType.AutoDual)]
      public class DotNetClass
      {
        public DotNetClass()
        {
        }
        public string DotNetMethod(string input)
        {
            return "Hello " + input;
        }
      }
    }
