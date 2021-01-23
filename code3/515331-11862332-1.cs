    protected override void OnBeforeInstall(System.Collections.IDictionary savedState) {
    	if (HasCommandParameter("settings")) {
    		// NB: Framework will surround this value with quotes when storing in registry
    		Context.Parameters["assemblypath"] += "\" \"settings=" + CommandParameter("settings");
    	}
    	base.OnBeforeInstall(savedState);
    }
    protected override void OnBeforeUninstall(System.Collections.IDictionary savedState) {
    	if (HasCommandParameter("settings")) {
    		// NB: Framework will surround this value with quotes when storing in registry
    		Context.Parameters["assemblypath"] += "\" \"settings=" + CommandParameter("settings");
    	}
    	base.OnBeforeUninstall(savedState);
    }
