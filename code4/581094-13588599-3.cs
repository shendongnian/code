    public interface ISmtpProvider : IoProvider
    {
        string PropertyB { get; set; }
        string PropertyC { get; set; }
    
        public void Configure()
        {
            PropertyB = ConfigurationManager.AppSettins["B"];
            PropertyB = ConfigurationManager.AppSettins["C"];
        }
    }
