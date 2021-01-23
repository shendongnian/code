        public static void UsingAbort<T>(this T client, Action<T> work)
            where T : ICommunicationObject
        {
            try
            {
                work(client);
                client.Abort();
            }
            catch (CommunicationException e)
            {
                Logger.Warn(e);
                client.Abort();
            }
            catch (TimeoutException e)
            {
                Logger.Warn(e);
                client.Abort();
            }
            catch (Exception e)
            {
                Logger.Warn(e);
                client.Abort();
                throw;
            }
        }
    }
