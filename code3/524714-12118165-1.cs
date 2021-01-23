    private static CustomBinding CreateCustomBinding(bool useHttps, bool textEncoding)
    {
        BindingElement security;
        BindingElement encoding;
        BindingElement transport;
        if (useHttps)
        {
            var seq = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            seq.MessageSecurityVersion =
                MessageSecurityVersion.
                    WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
            seq.SecurityHeaderLayout = SecurityHeaderLayout.Lax;
            seq.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Default;
                    
            security = seq;
            transport = new HttpsTransportBindingElement
            {
                MaxBufferPoolSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
            };
        }
        else
        {
            security = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            transport = new HttpTransportBindingElement
            {
                MaxBufferPoolSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
            };
        }
    
        if (textEncoding)
            encoding = new TextMessageEncodingBindingElement
            {
                MaxReadPoolSize = 64,
                MaxWritePoolSize = 16,
                MessageVersion = MessageVersion.Soap11,
                WriteEncoding = System.Text.Encoding.UTF8
            };
        else
            encoding = new MtomMessageEncodingBindingElement
            {
                MaxReadPoolSize = 64,
                MaxWritePoolSize = 16,
                MaxBufferSize = 2147483647,
                MessageVersion = MessageVersion.Soap11,
                WriteEncoding = System.Text.Encoding.UTF8
            };
    
        var customBinding = new CustomBinding();
    
        customBinding.Elements.Add(security);
        customBinding.Elements.Add(encoding);
        customBinding.Elements.Add(transport);
    
        return customBinding;
    }
