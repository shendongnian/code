    if (e.Result.Text.ToLower() == "battery level")   //First Change
    {
        System.Management.ManagementClass wmi = new System.Management.ManagementClass("Win32_Battery");
        var allBatteries = wmi.GetInstances();
        String estimatedChargeRemaining = String.Empty;
    
        foreach (var battery in allBatteries)
        {
           estimatedChargeRemaining = Convert.ToString(battery["EstimatedChargeRemaining"]);
           JARVIS.Speak("Estimated Charge Remaining: " + estimatedChargeRemaining + "%");  //second change as you may have more than one batteries.
        }       
        return;
    }
