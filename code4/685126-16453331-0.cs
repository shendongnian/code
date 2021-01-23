    using System.Security.Permissions;
    ...
    public void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
    {
        FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Write, path);
        try
        {
            permission.Demand();            
        }
        catch
        {
            e.Cancel = true;
        }
    }
