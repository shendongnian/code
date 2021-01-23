        private System.ServiceModel.Channels.Binding GetCustomBinding()
        {
            System.ServiceModel.Channels.AsymmetricSecurityBindingElement asbe = new AsymmetricSecurityBindingElement();
            asbe.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12;
            
            asbe.InitiatorTokenParameters = new System.ServiceModel.Security.Tokens.X509SecurityTokenParameters { InclusionMode = SecurityTokenInclusionMode.Never };
            asbe.RecipientTokenParameters = new System.ServiceModel.Security.Tokens.X509SecurityTokenParameters { InclusionMode = SecurityTokenInclusionMode.Never };
            asbe.MessageProtectionOrder = System.ServiceModel.Security.MessageProtectionOrder.SignBeforeEncrypt;
            asbe.SecurityHeaderLayout = SecurityHeaderLayout.Strict;
            asbe.EnableUnsecuredResponse = true;
            asbe.IncludeTimestamp = false;
            asbe.SetKeyDerivation(false);
            asbe.DefaultAlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Basic128Rsa15;
            asbe.EndpointSupportingTokenParameters.Signed.Add(new UserNameSecurityTokenParameters());
            asbe.EndpointSupportingTokenParameters.Signed.Add(new X509SecurityTokenParameters());
            CustomBinding myBinding = new CustomBinding();
            myBinding.Elements.Add(asbe);
            myBinding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8));
            HttpsTransportBindingElement httpsBindingElement = new HttpsTransportBindingElement();
            httpsBindingElement.RequireClientCertificate = true;
            myBinding.Elements.Add(httpsBindingElement);
            return myBinding;
        }
