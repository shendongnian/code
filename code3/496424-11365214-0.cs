                    try
                    {
                        var context = OperationContext.Current;
                        if (context != null)
                        {
                            var prop = context.IncomingMessageProperties;
    
                            if (prop != null && 
                                !string.IsNullOrEmpty(RemoteEndpointMessageProperty.Name) && 
                                prop.ContainsKey(RemoteEndpointMessageProperty.Name))
                            {
                                endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                            }
                        }                    
                    } 
                    catch (Exception e)
                    {
                        //log
                    }
//endpoint.Address - ip address
