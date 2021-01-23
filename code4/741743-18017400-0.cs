    //List all the users
    List<String> usersList = new List<String>();
    ManagementObjectSearcher sidQuery = new ManagementObjectSearcher("SELECT * FROM Win32_Account");
    ManagementObjectCollection results = sidQuery.Get();
    foreach (ManagementObject result in results)
    {
       usersList.Add(result["Name"])
    }
    //Check if profil has AppData folder
    List<String> usersAppData = new List<String>();
    String pathAppData = String.Empty;
    foreach(String user in usersList)
    {
       pathAppData = String.Format("{0}\Users\{1}\AppData", Environment.GetEnvironmentVariable("SystemRoot"), user);
       if(Directory.Exists(pathAppData ))
       {
          usersAppData.Add(pathAppData);
       }
    }
    //Here, you've got all the users AppData folder in usersAppData
