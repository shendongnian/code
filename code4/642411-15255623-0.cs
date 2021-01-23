    oWB.Close(false, strCurrentDir + strFile, Type.Missing);
    oWB.Dispose();
    wbks.Close();
    wbks.Dispose();
    oXL.Quit();
    oXL.Dispose();
    System.Runtime.InteropServices.Marshal.ReleaseComObject(oXL);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(wbks);
    System.Runtime.InteropServices.Marshal.ReleaseComObject(oWB);
