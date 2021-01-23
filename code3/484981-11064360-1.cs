    public static void addCheck(string checkName, string hostName, string port, string pollInterval, string alertEmail, string alertSMS, string alertURI)
    {
        checksCollection.Add(checkName, new YourClass() { 
            CheckName = checkName,
            etc...
        });
    }
