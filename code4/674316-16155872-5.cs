        public class WcfClientProxy<T> : RealProxy where T : class
        {
            private WcfChannelFactory<T> _channelFactory;
    
            public WcfClientProxy(WcfChannelFactory<T> channelFactory) : base(typeof(T))
            {
                this._channelFactory = channelFactory;
            }
    
            public override IMessage Invoke(IMessage msg)
            {
                // When a service method gets called, we intercept it here and call it below with methodBase.Invoke().
                var methodCall = msg as IMethodCallMessage;
                var methodBase = methodCall.MethodBase;
    
                // We can't call CreateChannel() because that creates an instance of this class,
                // and we'd end up with a stack overflow. So, call CreateBaseChannel() to get the
                // actual service.
                T wcfService = this._channelFactory.CreateBaseChannel();
                
                try
                {
                    var result = methodBase.Invoke(wcfService, methodCall.Args);
    
                    return new ReturnMessage(
                          result, // Operation result
                          null, // Out arguments
                          0, // Out arguments count
                          methodCall.LogicalCallContext, // Call context
                          methodCall); // Original message
                }
                catch (FaultException)
                {
                    // Need to specifically catch and rethrow FaultExceptions to bypass the CommunicationException catch.
                    // This is needed to distinguish between Faults and underlying communication exceptions.
                    throw;
                }
                catch (CommunicationException ex)
                {
                    // Handle CommunicationException and implement retries here.
                    throw new NotImplementedException();
                }            
            }
        }
