    public static void CloseClient(SocketClient whichClient)
            {
                ClientList.Remove(whichClient);
                whichClient.Client.Close();
                // dispose of the client object
                whichClient.Dispose();
                whichClient = null;
            }
