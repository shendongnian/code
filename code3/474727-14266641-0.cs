     public class BasicAuthenticationInvoker : Attribute, IOperationBehavior, IOperationInvoker
        {
            #region Private Fields
    
            private IOperationInvoker _invoker;
    
            #endregion
    
            #region IOperationBehavior Members
    
            public void ApplyDispatchBehavior(OperationDescription operationDescription,
                                              DispatchOperation dispatchOperation)
            {
                _invoker = dispatchOperation.Invoker;
                dispatchOperation.Invoker = this;
            }
    
            public void ApplyClientBehavior(OperationDescription operationDescription,
                                            ClientOperation clientOperation)
            {
            }
    
            public void AddBindingParameters(OperationDescription operationDescription,
                                             BindingParameterCollection bindingParameters)
            {
            }
    
            public void Validate(OperationDescription operationDescription)
            {
            }
    
            #endregion
    
            #region IOperationInvoker Members
    
            public object Invoke(object instance, object[] inputs, out object[] outputs)
            {
                if (Authenticate("Client Name here"))
                    return _invoker.Invoke(instance, inputs, out outputs);
                else
                {
                    outputs = null;
                    return null;
                }
            }
    
            public object[] AllocateInputs()
            {
                return _invoker.AllocateInputs();
            }
    
            public IAsyncResult InvokeBegin(object instance, object[] inputs,
                                            AsyncCallback callback, object state)
            {
                throw new NotSupportedException();
            }
    
            public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
            {
                throw new NotSupportedException();
            }
    
            public bool IsSynchronous
            {
                get
                {
                    return true;
                }
            }
    
            #endregion
    
            private bool Authenticate(string realm)
            {
                string[] credentials = GetCredentials(WebOperationContext.Current.IncomingRequest.Headers);
    
                if (credentials != null && credentials.Length == 2)
                {
                    // do auth here
                    var username = credentials[0];
                    var password = credentials[1];
    
                   // validate the username and password against whatever auth logic you have
    
                    return true; // if successful
                }
    
                WebOperationContext.Current.OutgoingResponse.Headers["WWW-Authenticate"] = string.Format("Basic realm=\"{0}\"", realm);
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Unauthorized;
                return false;
            }
    
            private string[] GetCredentials(WebHeaderCollection headers)
            {
                string credentials = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
                if (credentials != null)
                    credentials = credentials.Trim();
    
                if (!string.IsNullOrEmpty(credentials))
                {
                    try
                    {
                        string[] credentialParts = credentials.Split(new[] {' '});
                        if (credentialParts.Length == 2 && credentialParts[0].Equals("basic", StringComparison.OrdinalIgnoreCase))
                        {
                            credentials = Encoding.ASCII.GetString(Convert.FromBase64String(credentialParts[1]));
                            credentialParts = credentials.Split(new[] {':'});
                            if (credentialParts.Length == 2)
                                return credentialParts;
                        }
                    }
                    catch
                    {
                    }
                }
    
                return null;
            }
        }
