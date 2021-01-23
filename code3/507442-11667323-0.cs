    [Guid("E4435D3B-CBC3-4D41-B4A5-D8116B394195")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class Stringconcat_IAMCOM : IStringconcat_IAMCOM
    {
        public string stringconcat(string a, string b)
        {  
            EndpointAddress ep = new EndpointAddress("http://localhost:8000/stringconcatService/stringconcat");
            proxy = ChannelFactory<IStringconcat>.CreateChannel(new BasicHttpBinding(), ep);
            proxy.stringconcat(string a, string b);
        }
    }
    [Guid("E130F97E-1844-4C8B-9E57-AF42632A2557")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IStringconcat_IAMCOM
    {
        [DispId(1)]
        string stringconcat(string a, string b);
    }
