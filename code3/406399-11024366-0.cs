    var userAppName = "userprofile service2";
    SPFarm farm = SPFarm.Local;
    
    SPServiceApplication application;
    foreach (SPService s in farm.Services)
    {
        if(s.TypeName.Contains("User Profile Service"))
        {
            //We found UPS
            foreach(SPServiceApplication app in s.Applications)
            {
                if(app.Name == userAppName)
                    application = app; //Here is UPA
            }
        }
    }
    
    //Or if you like oneliner (not 100% safe)
    var x = farm.Services.First(s => s.TypeName.Contains("User Profile Service"))
              .Applications.FirstOrDefault(app => app.Name == userAppName);
