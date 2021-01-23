    XmlSerializer xs = new XmlSerializer(typeof(HostedService), "http://schemas.microsoft.com/windowsazure");
    var obj2 = (HostedService)xs.Deserialize(new StringReader(xml));
    
    public class HostedService
    {
        public string Url;
        public string ServiceName;
        public HostedServiceProperties HostedServiceProperties;
    }
    public class HostedServiceProperties
    {
        public string Description;
        public string Location;
        public string AffinityGroup;
        public string Label;
    }
