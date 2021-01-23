    using System.Threading.Tasks;
    public async static Task<string> ResolveDNS(string remoteHostName)
        {
            if (string.IsNullOrEmpty(remoteHostName))
                return string.Empty;
            string ipAddress = string.Empty;
            try
            {
                IReadOnlyList<EndpointPair> data =
                  await DatagramSocket.GetEndpointPairsAsync(new HostName(remoteHostName), "0");
                if (data != null && data.Count > 0)
                {
                    foreach (EndpointPair item in data)
                    {
                        if (item != null && item.RemoteHostName != null &&
                                      item.RemoteHostName.Type == HostNameType.Ipv4)
                        {
                            return item.RemoteHostName.CanonicalName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ipAddress = ex.Message;
            }
            return ipAddress;
        } 
