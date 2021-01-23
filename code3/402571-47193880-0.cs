          Service objService = new Service(objClass, "WSDualHttpBinding_ISendChatService");
                WSDualHttpBinding binding = objService.Endpoint.Binding as WSDualHttpBinding;
                int portNumber = FreeTcpPort();
                string hostName = Dns.GetHostName();
                binding.ClientBaseAddress = new Uri("http://"+Dns.GetHostByName(hostName).AddressList[0].ToString()+":" + portNumber + "/");            
                objService.Start(name);
    
    
    static int FreeTcpPort()
            {
                TcpListener l = new TcpListener(IPAddress.Loopback, 0);
                l.Start();
                int port = ((IPEndPoint)l.LocalEndpoint).Port;
                l.Stop();
                return port;
            }
