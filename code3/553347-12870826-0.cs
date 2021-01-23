        private void OnDataReceived(IAsyncResult asyn)
        {
            ReceiveState rState = (ReceiveState)asyn.AsyncState;
            Socket client = rState.Client;
            SocketError socketError = SocketError.TypeNotFound;
            if (!client.Connected)
            {
                // Not Connected anymore ?
                return;
            }
            _LastComms = DateTime.Now;
            _LastIn = _LastComms;
            int dataOffset = 0; 
            int restOfData = 0;
            int dataRead = 0;
            Boolean StreamClosed = false;
            long rStateDataLength = 0;
            long LastrStateDataLength = 0;
            try
            {
                dataRead = client.EndReceive(asyn, out socketError);
            }
            catch (Exception excpt)
            {
                // Handle error - use your own code..
                
            }
            if (socketError != SocketError.Success)
            {
                // Has Connection been lost ?
                OnConnectionDropped(client);
                return;
            }
            if (dataRead <= 0)
            {
                // Has connection been lost ?
                OnConnectionDropped(client);
                return;
            }
            while (dataRead > 0)
            {
                //check to determine what income data contain: size prefix or message
                if (!rState.DataSizeReceived)
                {
                    //there is already some data in the buffer
                    if (rState.Data.Length > 0)
                    {
                        restOfData = PrefixSize - (int)rState.Data.Length;
                        rState.Data.Write(rState.Buffer, dataOffset, restOfData);
                        dataRead -= restOfData;
                        dataOffset += restOfData;
                    }
                    else if (dataRead >= PrefixSize)
                    {  //store whole data size prefix
                        rState.Data.Write(rState.Buffer, dataOffset, PrefixSize);
                        dataRead -= PrefixSize;
                        dataOffset += PrefixSize;
                    }
                    else
                    {  // store only part of the size prefix
                        rState.Data.Write(rState.Buffer, dataOffset, dataRead);
                        dataOffset += dataRead;
                        dataRead = 0;
                    }
                    if (rState.Data.Length == PrefixSize)
                    {  //we received data size prefix 
                        rState.DataSize = BitConverter.ToInt32(rState.Data.GetBuffer(), 0);
                        rState.DataSizeReceived = true;
                        //reset internal data stream             
                        rState.Data.Position = 0;
                        rState.Data.SetLength(0);
                    }
                    else
                    {  //we received just part of the prefix information 
                        //issue another read
                        client.BeginReceive(rState.Buffer, 0, rState.Buffer.Length,
                           SocketFlags.None, new AsyncCallback(socketReadCallBack),
                              rState);
                        return;
                    }
                }
                //at this point we know the size of the pending data
                
                // Object disposed exception may raise here
                try
                {
                    rStateDataLength = rState.Data.Length;
                    LastrStateDataLength = rStateDataLength;
                }
                catch (ObjectDisposedException Ode)
                {
                    StreamClosed = true;
                }
                if (!StreamClosed)
                {
                    if ((rStateDataLength + dataRead) >= rState.DataSize)
                    {   //we have all the data for this message
                        restOfData = rState.DataSize - (int)rState.Data.Length;
                        rState.Data.Write(rState.Buffer, dataOffset, restOfData);
                        //Console.WriteLine("Data message received. Size: {0}",
                        //   rState.DataSize);
                        // Is this a heartbeat message ?
                        if (rState.Data.Length == 2)
                        {
                            // Yes
                            HeartBeatReceived();
                        }
                        else
                        {
                            //charArray = new char[uniEncoding.GetCharCount(
                            //byteArray, 0, count)];
                            //uniEncoding.GetDecoder().GetChars(
                            //    byteArray, 0, count, charArray, 0);
                            //Console.WriteLine(charArray);
                            //rState.Data.Position = 0;
                            DecodeMessageReceived(GetStringFromStream(rState.Data));
                        }
                        dataOffset += restOfData;
                        dataRead -= restOfData;
                        //message received - cleanup internal memory stream
                        rState.Data = new MemoryStream();
                        rState.Data.Position = 0;
                        rState.DataSizeReceived = false;
                        rState.DataSize = 0;
                        if (dataRead == 0)
                        {  
                            //no more data remaining to process - issue another receive
                            if (_IsConnected)
                            {
                                client.BeginReceive(rState.Buffer, 0, rState.Buffer.Length,
                                   SocketFlags.None, new AsyncCallback(socketReadCallBack),
                                      rState);
                                return;
                            }
                        }
                        else
                            continue; //there's still some data to process in the buffers
                    }
                    else
                    {  //there is still data pending, store what we've 
                        //received and issue another BeginReceive
                        if (_IsConnected)
                        {
                            rState.Data.Write(rState.Buffer, dataOffset, dataRead);
                            client.BeginReceive(rState.Buffer, 0, rState.Buffer.Length,
                               SocketFlags.None, new AsyncCallback(socketReadCallBack), rState);
                            dataRead = 0;
                        }
                    }
                }
                else
                {
                    // Stream closed, but have we read everything ?
                    if (LastrStateDataLength + dataRead == rState.DataSize)
                    {
                        // We're equal, get ready for more
                        //no more data remaining to process - issue another receive
                        if (_IsConnected)
                        {
                            client.BeginReceive(rState.Buffer, 0, rState.Buffer.Length,
                               SocketFlags.None, new AsyncCallback(socketReadCallBack),
                                  rState);
                        }
                        return;
                    }
                    else
                    {
                        // We should have more..
                        // Report Error
                    }
                }
                // If we've been disconnected, provide a graceful exit
                if (!_IsConnected)
                    dataRead = -1;
            }
         }
