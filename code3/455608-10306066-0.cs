            public UdpSocketClient(IPEndPoint remoteEndPoint, int localPort)
            {
                this.remoteEndPoint = remoteEndPoint;
    #if WINRT
                this.socket = new DatagramSocket();
                this.socket.MessageReceived += ReceiveCallback;
    
                Logger.Trace("{0}: Connecting to {1}.", this, remoteEndPoint);
                IAsyncAction connectAction = this.socket.ConnectAsync(remoteEndPoint.address, remoteEndPoint.port.ToString());
                connectAction.AsTask().Wait();
                Logger.Trace("{0}: Connect Complete. Status {1}, ErrorCode {2}", this, connectAction.Status, 
                    connectAction.ErrorCode != null ? connectAction.ErrorCode.Message : "None");
    
                dataWriter = new DataWriter(this.socket.OutputStream);
    #else
                ...
    #endif
            }
