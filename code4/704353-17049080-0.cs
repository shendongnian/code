    public class StateObject : IDisposable
        {
            // Client  socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public static int BufferSize = int.Parse(System.Configuration.ConfigurationManager.AppSettings["ListenerBufferSize"]); // 32768;  //32kb buffer
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            //debug string.
            public StringBuilder DebugData = new StringBuilder();
            //string of Ipaddress belonging to socket
            public string IpAddress = string.Empty;
            public int ByteCountReceived = 0;
            //Statistics
            public DateTime TimeSocketConnected = DateTime.Now;
            public DateTime TimeSocketDisconnected;
            public DateTime TimeLastDataPacketWasReceived;
            public DateTime TimeParsingRoutineStarted;
            public DateTime TimeParsingRoutineFinished;
            public double TotalSecondsConnected
            {
                get { return TimeSocketDisconnected.Subtract(TimeSocketConnected).TotalSeconds; }
            }
            public int ReceiveTimeout = int.Parse(System.Configuration.ConfigurationManager.AppSettings["TCPListenerV3_ReceiveTimeout"]); //15;
            private System.Timers.Timer _timer = new System.Timers.Timer();
            public bool IsDisposed { get; private set; }
            public void StartReceive()
            {
                _timer.Interval = ReceiveTimeout * 1000;
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
            public void ResetReceiveTimer()
            {
                _timer.Stop();
                _timer.Start();
            }
            private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                try
                {
                    DebugData.AppendLine(string.Format("[SOCKET RECEIVE TIMEOUT OCCURRED] - Ip: {0} Has not Sent any data for {1} seconds, and didn't disconnect on it's own. Byte Count Received: {2}",IpAddress, ReceiveTimeout, ByteCountReceived));
                    
                        if (!IsDisposed)
                        {
                            DebugData.AppendLine(string.Format("[SOCKET STATISTICS*] - Ip: {0}, Time Socket Connected: {1}, Time Socket Disconnected: {2}, Time Last Packet Received: {3}, Total Bytes Recvd: {4}, Total Seconds Connected: {5}"
                               , IpAddress, TimeSocketConnected, TimeSocketDisconnected, TimeLastDataPacketWasReceived, ByteCountReceived, TotalSecondsConnected));
                            workSocket.Disconnect(false);
                            workSocket.Shutdown(SocketShutdown.Both);
                            workSocket.Close();
                        }
                    
                    else
                    {
                        //socket isn't connected, stop the timer
                        _timer.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    //removed for reading purposes, just logged message to event log
                }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                try
                {
                    if (!IsDisposed)
                    {
                        if (disposing)
                        {
                            if (workSocket != null)
                            {
                                try //added on 6/10/2013
                                {
                                    _timer.Dispose();
                                    if (ME3ProsoftDataStreamService.listen.SocketConnected(workSocket))
                                    {
                                        TimeSocketDisconnected = DateTime.Now;
                                        workSocket.Disconnect(false);
                                        workSocket.Shutdown(SocketShutdown.Both);
                                        workSocket.Close();
                                    }
                                    
                                }
                                catch (Exception ex1)
                                {
                                    //removed for reading purposes, just logged message to event log
                                }
                            }
                        }
                    }
                    workSocket = null;
                    buffer = null;
                    //DebugData.Length = 0;
                    IpAddress = null;
                    IsDisposed = true;
                }
                catch (Exception ex)
                {
                    //removed for reading purposes, just logged message to event log
                }
            }
        }
