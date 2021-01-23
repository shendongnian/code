   	using (ShimsContext.Create())
            {
                
                var response = new ShimOutgoingWebResponseContext();
                var ctx = new ShimWebOperationContext
                {
                    OutgoingResponseGet = () => response
                };
                ShimWebOperationContext.CurrentGet = () => ctx;
                try
                {
                    ParameterInspector.BeforeCall("operationName", new string[]{"some_argument"} );
                }
                catch (Exception e)
                {
                    Assert.IsNull(e);
                }
            }
