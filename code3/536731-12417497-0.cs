     private void WaitForData()
        {
            try
            {
                if (socketReadCallBack == null)
                {
                    socketReadCallBack = new AsyncCallback(OnDataReceived);
                }
                ReceiveState rState = new ReceiveState();
                rState.Client = mySocket;
                mySocket.BeginReceive(rState.Buffer, 0, rState.Buffer.Length, SocketFlags.None,
                    new AsyncCallback(socketReadCallBack), rState);
            }
            catch (SocketException excpt)
            {
                // Process Exception
            }
        }
