    var oldPrinter = printerFunctions.OpenPrinterHandle(String.Format(@"{0}\{1}", oldServerName, oldPrinterName));
    var printerInfo8 = printerFunctions.GetPrinterInfo<PRINTER_INFO_8>(oldPrinter, 8);
    // Change the dmDuplex value here.
    printerFunctions.SetPrinter(oldPrinter, printerInfo8, 8);
    printerFunctions.ClosePrinterHandle(oldPrinter);
    public IntPtr OpenPrinterHandle(string printerName)
    {
        var def = new PRINTER_DEFAULTS { pDatatype = null, pDevMode = IntPtr.Zero, DesiredAccess = OpenPrinterAccessCodes.PRINTER_ALL_ACCESS };
        var hPrinter = IntPtr.Zero;
        if (!PrinterNativeMethods.OpenPrinter(printerName, ref hPrinter, def))
        {
            var lastWin32Error = new Win32Exception(Marshal.GetLastWin32Error());
            Logger.Log("Failed open Printer: " + lastWin32Error.Message);
            throw lastWin32Error;
        }
        return hPrinter;
    }
    
    public void ClosePrinterHandle(IntPtr hPrinter)
    {
        PrinterNativeMethods.ClosePrinter(hPrinter);
    }
    
    public void SetPrinter<T>(IntPtr hPrinter, T printerInfo, uint level)
    {
        var size = (uint)Marshal.SizeOf(printerInfo);
        var printerInfoPtr = Marshal.AllocHGlobal((int)size);
        Marshal.StructureToPtr(printerInfo, printerInfoPtr, true);
        var result = PrinterNativeMethods.SetPrinter(hPrinter, level, printerInfoPtr, 0);
        if (!result)
        {
            var win32Error = Marshal.GetLastWin32Error();
            var lastWin32Error = new Win32Exception(win32Error);
            Logger.Log("Failed set printer: " + lastWin32Error.Message);
            throw lastWin32Error;
        }
        Marshal.FreeHGlobal(printerInfoPtr);
    }
    
    public T GetPrinterInfo<T>(IntPtr hPrinter, uint level)
    {
        uint pcbNeeded;
        var bFlag = PrinterNativeMethods.GetPrinter(hPrinter, level, IntPtr.Zero, 0, out pcbNeeded);
        var win32Error = Marshal.GetLastWin32Error();
        if ((!bFlag) && (win32Error != PrinterNativeMethods.ERROR_INSUFFICIENT_BUFFER) || (pcbNeeded == 0))
        {
            var lastWin32Error = new Win32Exception(win32Error);
            Logger.Log("Failed get printer: " + lastWin32Error.Message);
            throw lastWin32Error;
        }
    
        var currentPrinterInfoPtr = Marshal.AllocHGlobal((int)pcbNeeded);
        bFlag = PrinterNativeMethods.GetPrinter(hPrinter, level, currentPrinterInfoPtr, pcbNeeded, out pcbNeeded);
        if (!bFlag)
        {
            var lastWin32Error = new Win32Exception();
            Logger.Log("Failed get printer: " + lastWin32Error.Message);
            throw lastWin32Error;
        }
        return (T)Marshal.PtrToStructure(currentPrinterInfoPtr, typeof(T));
    }
