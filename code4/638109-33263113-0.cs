    void currDomain_DomainUnload(object sender, EventArgs e)
        {
            _log.Debug(FormatLogMessage(_identity, "Domain unloading Event!"));
            _cancellationTokenSource.Cancel();
            _logPlayer.Dispose();
        }
     void currDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _log.Error(string.Format("***APP Domain UHE*** Error:{0}", e.ExceptionObject);
            _cancellationTokenSource.Cancel();
            _logPlayer.Dispose();
        }
