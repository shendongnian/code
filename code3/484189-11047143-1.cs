    public class ClientService<TProxy>
    {
        private static ChannelFactory<TProxy> channelFactory = new ChannelFactory<TProxy>("*");
    
        public static void SendData(Action<TProxy> codeBlock)
        {
            var proxy = (IClientChannel) channelFactory.CreateChannel();
            bool success = false;
            
            try
            {
                codeBlock((TProxy)proxy);
                proxy.Close();
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }
    
        public static TResult GetData<TResult>(Func<TProxy, TResult> codeBlock)
        {
            var proxy = (IClientChannel) channelFactory.CreateChannel();
            bool success = false;
            
            TResult result;
            try
            {
                result = codeBlock((TProxy)proxy);
                proxy.Close();
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
    
            return result;
        }
    }
    public class SomeAnotherService<TProxy>
    {
        public static bool SendData(Action<TProxy> codeBlock)
        {
            try
            {
                ClientService<TProxy>.SendData(codeBlock);
                return true;
            }
            catch(Exception ex)
            {
                //...
            }
            return false;
        }
    
        public static TResult GetData<TResult>(Func<TProxy, TResult> codeBlock)
        {
            TResult result = default(TResult);
            try
            {
                result = ClientService<TProxy>.GetData(codeBlock);
            }
            catch (Exception ex)
            {
                //...
            }
            
            return result;
        }
    }
