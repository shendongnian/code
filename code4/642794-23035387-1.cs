    var binding = new BasicHttpBinding { MaxReceivedMessageSize = 1000000, ReaderQuotas = { MaxDepth = 200 } };
    
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
    binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
