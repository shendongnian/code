    protected override void OnCommitting(System.Collections.IDictionary savedState)
    {
        string installedPath = string.Empty;
        installedPath = Context.Parameters["assemblypath"];
        installedPath = installedPath.Substring(0, installedPath.LastIndexOf('\\'));
        File.Delete(Path.Combine(installedPath, "InstallerHelper.InstallState"));
        base.OnCommitting(savedState);
    }
