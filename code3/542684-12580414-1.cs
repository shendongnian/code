    private static string GetMOValue(ManagementObject mo, string name)
    {
        try
        {
            object result = mo[name];
            return result == null ? "" : result.ToString();
        }
        catch(Exception)
        {
            return "WMI Error";
        }
    }
    ...
    lblSystemName.Text = GetMOValue(moDisk, "systemname");
    lblType.Text = GetMOValue(moDisk, "MediaType");
