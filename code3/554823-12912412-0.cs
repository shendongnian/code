    try
                {
                    using (var tcpClient = new StreamSocket())
                    {
                        await tcpClient.ConnectAsync(
                            new Windows.Networking.HostName(HostName),
                            PortNumber,
                            SocketProtectionLevel.PlainSocket);
    
                        var localIp = tcpClient.Information.LocalAddress.DisplayName;
                        var remoteIp = tcpClient.Information.RemoteAddress.DisplayName;
    
                        ConnectionAttemptInformation = String.Format("Success, remote server contacted at IP address {0}",
                                                                     remoteIp);
                        tcpClient.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    if (ex.HResult == -2147013895)
                    {
                        ConnectionAttemptInformation = "Error: No such host is known";
                    }
                    else if (ex.HResult == -2147014836)
                    {
                        ConnectionAttemptInformation = "Error: Timeout when connecting (check hostname and port)";
                    }
                    else
                    {
                        ConnectionAttemptInformation = "Error: Exception returned from network stack: " + ex.Message;
                    }
                }
                finally
                {
                    ConnectionInProgress = false;
                }
