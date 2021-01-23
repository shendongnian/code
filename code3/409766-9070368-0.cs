    internal static WServiceSoapClient CreateWebServiceInstance()
    {
        BasicHttpBinding binding = new BasicHttpBinding();
        binding.SendTimeout = TimeSpan.FromMinutes(1);
        binding.OpenTimeout = TimeSpan.FromMinutes(1);
        binding.CloseTimeout = TimeSpan.FromMinutes(1);
        binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
        binding.AllowCookies = false;
        binding.BypassProxyOnLocal = false;
        binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
        binding.MessageEncoding = WSMessageEncoding.Text;
        binding.TextEncoding = System.Text.Encoding.UTF8;
        binding.TransferMode = TransferMode.Buffered;
        binding.UseDefaultWebProxy = true;
        return new WServiceSoapClient(binding, new EndpointAddress("http://yourservice.com/service.asmx"));
    }
