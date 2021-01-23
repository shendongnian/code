    protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                _batchScheduleInterval = Convert.ToInt32(ApplicationConfigurationManager.Properties["BatchScheduleInterval"]);
            }
            catch(InvalidCastException err)
            {
                TextLogger.Log(err.Message);
            }
            Helper.SaveKioskApplicationStatusLog(Constant.APP_START);
            if (SessionManager.Instance.DriverId == null && _batchScheduleInterval!=0)
            {
                InitializeApplicationSyncTimer();
                InitializeDatabaseConnectionCheckTimer();
                IntializeImageSyncTimer();
            }
        }
