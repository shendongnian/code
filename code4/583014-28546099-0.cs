    <pre>
            public static IPAddress GetDefaultGateway()
            {
                IPAddress result = null;
                var cards = NetworkInterface.GetAllNetworkInterfaces().ToList();
                if (cards.Any())
                {
                    foreach(var card in cards)
                    {
                        var props = card.GetIPProperties();
                        if (props == null) 
                            continue;
                        var gateways = props.GatewayAddresses;
                        if (!gateways.Any()) 
                            continue;
                        var gateway =
                            gateways.FirstOrDefault(g => g.Address.AddressFamily.ToString() == "InterNetwork");
                        if (gateway == null) 
                            continue;
                        result = gateway.Address;
                        break;
                    };
                }
                return result;
            } 
    <pre>
