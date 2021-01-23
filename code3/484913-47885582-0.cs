    // Check whether the U-TEST RTC service is started.
            ServiceController sc = new ServiceController();
            sc.ServiceName = "U-TEST RTC";
            m_objMainChainRTC.m_objUC.ValidationLogMessages(String.Format(LocalizeDictionary.Instance.GetLocalizedValue("MsgStatusService"), sc.Status.ToString()), Alstom.Automation.Forms.ViewModels.RTCAutomationViewModel.ColorLog.Log);
    
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                m_objMainChainRTC.m_objUC.ValidationLogMessages(String.Format(LocalizeDictionary.Instance.GetLocalizedValue("MsgStartService")), Alstom.Automation.Forms.ViewModels.RTCAutomationViewModel.ColorLog.Log);
                try
                {
                    // Start the service, and wait until its status is "Running".
                    sc.Start();
                    var timeout = new TimeSpan(0, 0, 5); // 5seconds
                    sc.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    m_objMainChainRTC.m_objUC.ValidationLogMessages(String.Format(LocalizeDictionary.Instance.GetLocalizedValue("MsgNowService"), sc.Status.ToString()), Alstom.Automation.Forms.ViewModels.RTCAutomationViewModel.ColorLog.Log);
                }
                catch (InvalidOperationException)
                {
                    m_objMainChainRTC.m_objUC.ValidationLogMessages(String.Format(LocalizeDictionary.Instance.GetLocalizedValue("MsgExceptionStartService")), Alstom.Automation.Forms.ViewModels.RTCAutomationViewModel.ColorLog.Log);
                }
            }
