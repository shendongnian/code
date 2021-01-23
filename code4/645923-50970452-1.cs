    public static string Version {
    	get {
    		using (StreamReader resourceReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("SBRL.GlidingSquirrel.release-version.txt")))
    		{
    			return resourceReader.ReadToEnd().Trim();
    		}
    	}
    }
