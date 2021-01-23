    using System;
    using System.Runtime.InteropServices;
    
    namespace MyCSharpClass
    {
        [ComVisible(true)] // Don't forget 
        [ClassInterface(ClassInterfaceType.AutoDual)] // these two lines
        [Guid("485B98AF-53D4-4148-B2BD-CC3920BF0ADF")] // or this GUID
        public class TheClass
        {
            public String GetTheThing(String arg) // Make sure this is public
            {
                return arg + "the thing";
            }
        }
    }
