        try
           {
               m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
               // Cet the remote IP address
               IPAddress ip = IPAddress.Parse(passedTCPObject.ipString);
               int iPortNo = System.Convert.ToInt16(passedTCPObject.portString);
               // Create the end point 
               ipEnd = new IPEndPoint(ip, iPortNo);
               Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
               SocketPacket theSocPkt = new SocketPacket();
               if (m_pfnCallBack == null)
               {
                   m_pfnCallBack = new AsyncCallback(OnDataReceived);
               }
               // Give It 5 Seconds to connect
               IAsyncResult result = socket.BeginConnect(ipEnd, m_pfnCallBack, theSocPkt);
               bool success = result.AsyncWaitHandle.WaitOne(5000, true);
               if (!success)
               {
                   socket.Close();
                   throw new ApplicationException("Server Refused Connection");
               }
               // Success
               updateStatus(true);
           }
           catch (SocketException e)
           {
               updateStatus(false);
               return;
           }
           catch (Exception e)
           {
               updateStatus(false);
               return;
           }
 
