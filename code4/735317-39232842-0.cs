    public string IpEndPoint
        {
            get
            {
                return NetworkInterface.GetAllNetworkInterfaces()
               .Where(ni => ni.Name.Equals("en0"))
               .First().GetIPProperties().UnicastAddresses
               .Where(add => add.Address.AddressFamily == AddressFamily.InterNetwork)
               .First().Address.ToString();
            }
        }
