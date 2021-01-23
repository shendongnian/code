    protected override void OnStart(string[] args)
    {
        try
        {
            _bridgeServiceEventLog.WriteEntry("new OnStart");
                     if (LicenseValidetor.ValidCountAndTypeDevices())
                {
                    WsInitializeBridge();
                }
                     else
                     {
    
                       int time = 10000;
    
                       TimeSpan timeout = TimeSpan.FromMilliseconds(time);
    
                       service.Stop();
                       service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                        
                       _bridgeServiceEventLog.WriteEntry("LicenseValidetor Error");
    
                }
            _bridgeServiceEventLog.WriteEntry("end Start");
        }
        catch (Exception e)
        {
            _bridgeServiceEventLog.WriteEntry("error In onstart method ");
        }
