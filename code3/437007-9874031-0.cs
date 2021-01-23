    public static TResult ExecuteRequest<TChannel, TResult>(
                                                               this ChannelFactory<TChannel> factory,
                                                               Func<TChannel, TResult> readDelegate)
        {
            if (factory == null || readDelegate == null)
            {
                return default(TResult);
            }
    
            TChannel channel = factory.CreateChannel();
    #if DEBUG
            // Changes the timeout to 10 minutes so you can step through server
            // code if you need to without getting a timeout error.
            ((IClientChannel)channel).OperationTimeout = TimeSpan.FromMinutes(10);
    #endif
            TResult result;
            try
            {
                result = readDelegate(channel);
                var client = (IClientChannel)channel;
                CommunicationState state = client.State;
                if (state != CommunicationState.Faulted)
                {
                    client.Close();
                }
                else
                {
                    client.Abort();
                }
            }
            catch (Exception)
            {
                ((IClientChannel)channel).Abort();
                throw;
            }
            finally
            {
                ((IClientChannel)channel).DisposeSafe();
            }
    
            return result;
        }
