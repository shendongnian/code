    public static IEnumerable<IPAddress> GetIpAddress()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                return (from ip in host.AddressList where !IPAddress.IsLoopback(ip) select ip).ToList();
            }
