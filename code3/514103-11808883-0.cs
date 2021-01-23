    public AxKylixSMS SMS;
    
    SMS = new AxKylixSMS();            
    
    SMS.CreateControl();
    
    SMS.NewDeliveryReport += new   _DKylixSMSEvents_NewDeliveryReportEventHandler(this.OnDeliveryReport);
