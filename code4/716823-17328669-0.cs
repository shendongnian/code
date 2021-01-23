    // Read bytes in from file, capture length of returned array
    var bytes = File.ReadAllBytes(szFileName);
    var nLength = bytes.Length;
    // Your unmanaged pointer.
    IntPtr pUnmanagedBytes = new IntPtr(0);
    // Allocate some unmanaged memory for those bytes.
    pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
    // Copy the managed byte array into the unmanaged array.
    Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
    // Send the unmanaged bytes to the printer.
    var bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
    // Free the unmanaged memory that you allocated earlier.
    Marshal.FreeCoTaskMem(pUnmanagedBytes);
    return bSuccess;
