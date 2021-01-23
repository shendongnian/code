    if (client != null)
    {
        if (client.Connected)
        {
            client.GetStream().Close();
        }
        client.Close();
        client = null;
    }
