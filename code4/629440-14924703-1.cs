    var applicationConfigs = new[] {
    	new { ApplicationID = 1, ConfigurationID = 1, Name = "Application #1" },
    	new { ApplicationID = 2, ConfigurationID = 1, Name = "Application #2" },
    	new { ApplicationID = 3, ConfigurationID = 2, Name = "Application #3" },
    	new { ApplicationID = 4, ConfigurationID = 2, Name = "Application #4" }
    };
    var groupApplicationConfigs = new[] {
    	new { ApplicationID = 1, ConfigurationID = 1, Name = "Group App Config #1" },
    	new { ApplicationID = 1, ConfigurationID = 1, Name = "Group App Config #2" },
    	new { ApplicationID = 2, ConfigurationID = 1, Name = "Group App Config #3" },
    	new { ApplicationID = 3, ConfigurationID = 1, Name = "Group App Config #4" }
    };
    
    //JOIN + WHERE
    var q = from a in applicationConfigs
            join ga in groupApplicationConfigs 
                on a.ApplicationID equals ga.ApplicationID 
            where a.ConfigurationID == ga.ConfigurationID
            select a;
    Console.WriteLine(q);
    		
    //ANONYMOUS TYPE
    var r = from a in applicationConfigs
            join ga in groupApplicationConfigs 
                on new { a.ApplicationID, a.ConfigurationID } equals 
                   new { ga.ApplicationID, ga.ConfigurationID }
            select a;
    Console.WriteLine(r);
