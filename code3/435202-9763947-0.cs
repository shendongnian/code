    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
    	<applicationSettings>
    	
    	</applicationSettings>
    	<appSettings>
    		<add key="ReadIndex" value="C:\Index"/>
    	</appSettings>
    </configuration>
    var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
    var location = executingAssembly.Location; //C:\MyApp\bin\Debug\Search.dll
    var config = ConfigurationManager.OpenExeConfiguration(location);
    var sections = config.Sections; //count of this is 21
    string s = config.AppSettings.Settings["ReadIndex"].Value.ToString();
