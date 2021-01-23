    using Microsoft.Office.Interop.Access;
    using System.Runtime.InteropServices
    ...
    
    try
    {
        var msAccess = (Application)Marshal.GetActiveObject("Access.Application");
        msAccess.OpenCurrentDatabase(@"x:\foo\bar.accdb", false);
        msAccess.DoCmd.RunMacro("macCTI");
        msAccess.CloseCurrentDatabase();
    }
    catch (COMException ex)
    {
        // handle error
    }
    
