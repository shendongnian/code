    if (e.Result.Text.ToLower() == "battery level")
    {
        System.Management.ManagementClass wmi = new System.Management.ManagementClass("Win32_Battery");
        var allBatteries = wmi.GetInstances();
        //String estimatedChargeRemaining = String.Empty;
        int batteryLevel = 0;
        foreach (var battery in allBatteries)
        {
            batteryLevel = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
        }
  
        if(batteryLevel < 25)       
           JARVIS.Speak("Warning, Battery level has dropped below 25%");
        else //Guessing you want else
           JARVIS.Speak("The Power Level Is At: " + batteryLevel.ToString() + "% sir");
        return;
    }
