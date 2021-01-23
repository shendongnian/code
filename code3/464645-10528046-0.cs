    get
    {
        if (_appCuKey == null)
        {
            _appCuKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(AppRegyPath, true);
            if (_appCuKey == null)
                _appCuKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(AppRegyPath);
        }
        return _appCuKey;
    }
    set { _appCuKey = null; }
