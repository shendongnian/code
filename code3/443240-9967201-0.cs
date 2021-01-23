    using System.Runtime.InteropServices;
    ...
    Excel.Application xl = null; 
    try {
        // Try to get an existing instance
        xl = (Excel.Application)Marshal.GetActiveObject("Excel.Application"); 
    } catch (COMException ex) { 
        // Excel was not open. Open a new instance
        xl = new Excel.ApplicationClass(); 
    } 
