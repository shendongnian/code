    try
    {
        DirectoryContext context = new DirectoryContext(DirectoryContextType.DirectoryServer,   "IP", "Username", "Password");
        DirectoryEntry deDoc = Domain.GetDomain(context).GetDirectoryEntry();
    }
    catch (Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
