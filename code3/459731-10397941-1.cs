    using Microsoft.Office.Interop.Access;
    using System.Runtime.InteropServices
    ...
    try
    {
        var msAccess = (Application)Marshal.GetActiveObject("Access.Application");
        msAccess.DoCmd.RunMacro("macCTI");
    }
    catch (COMException ex)
    {
        // handle error
    }
