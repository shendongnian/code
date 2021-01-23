    private async void App_UnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
        string appName = Package.Current.Id.Name;
        var version = Package.Current.Id.Version;
        string appVersion = String.Format("{0}.{1}.{2}.{3}", 
            version.Major, version.Minor, version.Build, version.Revision);
        WAMS_EXCEPTIONLOG wamsel = new WAMS_EXCEPTIONLOG
        {
            appNameAndVersion = string.Format("{0} {1}", appName, appVersion),
            ExceptionMsg = args.Exception.Message,
            InnerException = args.Exception.InnerException.ToString(),
            ExceptionToStr = args.Exception.ToString(),
            dateTimeOffsetStamp = DateTimeOffset.UtcNow
        };
        args.Handled = true;
        await MobileService.GetTable<TASLS_WAMS_EXCEPTIONLOG>().InsertAsync(wamsel);
    }
