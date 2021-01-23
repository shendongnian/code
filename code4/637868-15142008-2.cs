    // variable name changed by corsiKa
    public void CloseNode(bool acceptMoreConnections)
    {
        try
        {
            if (Handler != null)
            {
                Handler.Shutdown(SocketShutdown.Both);
                Handler.Close();
                Handler.Dispose();
                Handler = null;
            }
            // changed by corsiKa
            if (acceptMoreConnections)
                performListen(listener);
        }
        catch (Exception e)
        {
            invokeStatusUpdate(0, e.Message);
        }
    }
