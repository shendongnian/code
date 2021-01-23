    private static bool IsBindingSupported(Binding binding)
    {
        if ((!(binding is BasicHttpBinding) && !(binding is CustomBinding)) && (!(binding is WSHttpBinding) && !(binding is NetTcpBinding)))
        {
            return false;
        }
        if (binding is WSHttpBinding)
        {
            if (((WSHttpBinding) binding).ReliableSession.Enabled)
            {
                return false;
            }
            if (((WSHttpBinding) binding).TransactionFlow)
            {
                return false;
            }
            if (((WSHttpBinding) binding).MessageEncoding != WSMessageEncoding.Text)
            {
                return false;
            }
        }
        if (binding is NetTcpBinding)
        {
            if (((NetTcpBinding) binding).ReliableSession.Enabled)
            {
                return false;
            }
            if (((NetTcpBinding) binding).TransactionFlow)
            {
                return false;
            }
        }
        foreach (BindingElement element in binding.CreateBindingElements())
        {
            if (element is TransportBindingElement)
            {
                if ((!(element is HttpTransportBindingElement) && (!(element is HttpsTransportBindingElement) || (element as HttpsTransportBindingElement).RequireClientCertificate)) && !(element is TcpTransportBindingElement))
                {
                    return false;
                }
            }
            else if (element is MessageEncodingBindingElement)
            {
                if (!(element is BinaryMessageEncodingBindingElement) || (((BinaryMessageEncodingBindingElement) element).MessageVersion != MessageVersion.Soap12WSAddressing10))
                {
                    if (element is TextMessageEncodingBindingElement)
                    {
                        if ((((TextMessageEncodingBindingElement) element).MessageVersion != MessageVersion.Soap11) && (((TextMessageEncodingBindingElement) element).MessageVersion != MessageVersion.Soap12WSAddressing10))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (element is SecurityBindingElement)
            {
                if (!(element is TransportSecurityBindingElement))
                {
                    return false;
                }
                TransportSecurityBindingElement element2 = (TransportSecurityBindingElement) element;
                if (!ValidateUserNamePasswordSecurityBindingElement(element2))
                {
                    if (((((element2.EndpointSupportingTokenParameters.Endorsing.Count == 1) && (element2.EndpointSupportingTokenParameters.Signed.Count == 0)) && ((element2.EndpointSupportingTokenParameters.SignedEncrypted.Count == 0) && (element2.EndpointSupportingTokenParameters.SignedEndorsing.Count == 0))) && ((element2.EndpointSupportingTokenParameters.Endorsing[0] is SecureConversationSecurityTokenParameters) && ((element2.MessageSecurityVersion == MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10) || (element2.MessageSecurityVersion == MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10)))) && ((element2.IncludeTimestamp && (element2.DefaultAlgorithmSuite == SecurityAlgorithmSuite.Default)) && (element2.SecurityHeaderLayout == SecurityHeaderLayout.Strict)))
                    {
                        SecureConversationSecurityTokenParameters parameters = (SecureConversationSecurityTokenParameters) element2.EndpointSupportingTokenParameters.Endorsing[0];
                        if (parameters.RequireDerivedKeys || !(parameters.BootstrapSecurityBindingElement is TransportSecurityBindingElement))
                        {
                            return false;
                        }
                        TransportSecurityBindingElement bootstrapSecurityBindingElement = (TransportSecurityBindingElement) parameters.BootstrapSecurityBindingElement;
                        if (!ValidateUserNamePasswordSecurityBindingElement(bootstrapSecurityBindingElement))
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if ((!(element is SslStreamSecurityBindingElement) || (element as SslStreamSecurityBindingElement).RequireClientCertificate) && !(element is WindowsStreamSecurityBindingElement))
            {
                if (!(element is TransactionFlowBindingElement))
                {
                    return false;
                }
                if ((!(binding is WSHttpBinding) || ((WSHttpBinding) binding).TransactionFlow) && (!(binding is NetTcpBinding) || ((NetTcpBinding) binding).TransactionFlow))
                {
                    return false;
                }
            }
        }
        return true;
    }
