    public static bool IsOutlookInstalled()
    {
        try
        {
            Type type = Type.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")); //Outlook.Application
            if (type == null) return false;
            object obj = Activator.CreateInstance(type);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            return true;
        }
        catch (COMException)
        {
            return false;
        }
    }
