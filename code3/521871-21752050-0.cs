     try
                {
                  //wcf service call
                }
                catch (FaultException ex)
                {
                   throw new Exception( (ex as WebFaultException<MyContractApplicationFault>).Detail.MyContractErrorMessage );                
                }
