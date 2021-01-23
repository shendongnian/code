    public void InstallApplications()
    {
        foreach (App app in this._apps)
        {
            if (ApplicationShouldBeInstalled(app)) {
                CommonUtility.Container
                    .Resolve<IAppInstaller>()
                    .InstallApplication(this, app);
            }
        }                       
    }
