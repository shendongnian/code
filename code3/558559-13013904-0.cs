    public static void CloseConnection(this ICommunicationObject client)
    {
      if (client.State != CommunicationState.Opened)
      {
        return;
      }
      try
      {
        client.Close();
      }
      catch (CommunicationException)
      {
        client.Abort();
        throw;
      }
      catch (TimeoutException)
      {
        client.Abort();
        throw;
      }
      catch (Exception)
      {
        client.Abort();
        throw;
      }
    }
