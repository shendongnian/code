    /// <summary>
            /// Method will disconnect this peer forcefully
            /// </summary>
            public void Disconnect()
            {
                try
                {
                    PeerStream.Close();
                }
                catch (Exception ee)
                {
                }
                try
                {
                    _client.Client.Disconnect(false);
                }
                catch (Exception ee)
                {
    
                }
            }
