    var binding = new BasicHttpBinding()
                {
                    CloseTimeout = new TimeSpan(0, 1, 0),
                    OpenTimeout = new TimeSpan(0, 1, 0),
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
                    SendTimeout = new TimeSpan(0, 1, 0),
                    AllowCookies = false,
                    BypassProxyOnLocal = false,
                    HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                    MaxBufferSize = 65536,
                    MaxBufferPoolSize = 524288,
                    MaxReceivedMessageSize = 65536,
                    MessageEncoding = WSMessageEncoding.Text,
                    TextEncoding = Encoding.UTF8,
                    TransferMode = TransferMode.Buffered,
                    UseDefaultWebProxy = true
                };
                binding.ReaderQuotas.MaxDepth = 32;
                binding.ReaderQuotas.MaxStringContentLength = 8192;
    if (isHttps)
        binding.Security = new BasicHttpSecurity() { Mode = BasicHttpSecurityMode.Transport };
