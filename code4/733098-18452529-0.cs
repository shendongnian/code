    protected void Application_Start() {
        var privateFieldFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic;
        //Get session state section
        var sessionStateSection = ConfigurationManager.GetSection("system.web/sessionState") as SessionStateSection;
        var values = typeof(ConfigurationElement).GetField("_values", privateFieldFlags).GetValue(sessionStateSection);
        var entriesArray = values.GetType().BaseType.GetField("_entriesArray", privateFieldFlags).GetValue(values);
        //Get "Mode" entry (index: 2)
        var modeEntry = (entriesArray as System.Collections.ArrayList)[2];
        var entryValue = modeEntry.GetType().GetField("Value", privateFieldFlags).GetValue(modeEntry);
        //Change entry value to InProc
        entryValue.GetType()
				.GetField("Value", privateFieldFlags)
				.SetValue(entryValue, System.Web.SessionState.SessionStateMode.InProc);
    }
