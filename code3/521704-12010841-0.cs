    /* From ShObjIdl.idl
    // CLSID_AppVisibility
    [ uuid(7E5FE3D9-985F-4908-91F9-EE19F9FD1514)] coclass AppVisibility { interface IAppVisibility; }
     */
    Type tIAppVisibility = Type.GetTypeFromCLSID(new Guid("7E5FE3D9-985F-4908-91F9-EE19F9FD1514"));
    IAppVisibility appVisibility = (IAppVisibility)Activator.CreateInstance(tIAppVisibility);
    bool launcherVisible;
    if(HRESULT.S_OK == appVisibility.IsLauncherVisible(out launcherVisible)) {
        // Here you can use the launcherVisible flag
    }
