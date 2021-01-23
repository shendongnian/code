                public void WaitForData(System.Net.Sockets.Socket soc)
                {
                    try
                    {
                       if (pfnWorkerCallBack == null)
                       {
                           // Specify the call back function which is to be 
                          // invoked when there is any write activity by the 
                          // connected client
                          pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                       }
                        SocketPacket theSocPkt = new SocketPacket();
                        theSocPkt.m_currentSocket = soc;
                       // Start receiving any data written by the connected client
                       // asynchronously
                        soc.BeginReceive(theSocPkt.dataBuffer, 0,                                                      theSocPkt.dataBuffer.Length,
                                   SocketFlags.None,
                                   pfnWorkerCallBack,
                                   theSocPkt);
                        }
                        catch (SocketException se)
                        {
                            MessageBox.Show(se.Message);
                        }
                   } 
