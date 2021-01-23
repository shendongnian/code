    private static string GetMOValue(ManagementObject mo, string name)
    {
        try
        {
            return mo[name].ToString();
        }
        catch(Exception)
        {
            return "WMI Error";
        }
    }
    ...
    lblSystemName.Text = GetMOValue(moDisk, "systemname");
    lblType.Text = GetMOValue(moDisk, "MediaType");
