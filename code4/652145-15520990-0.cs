    public WebService1() {
        string urlSetting = System.Configuration.ConfigurationManager.AppSettings["ConfigKeyForServiceUrl"];
        if ((urlSetting != null)) {
            this.Url = urlSetting;
        }
        else {
            this.Url = "http://localhost:65304/WebService1.asmx";
        }
    }
