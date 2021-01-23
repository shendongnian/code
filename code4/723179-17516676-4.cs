    class Program
    {
        private static void Main(string[] args)
        {
            Timer ticker = new Timer(Update, null, 0, 1000);
            // Keep the main thread from dying
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
        private static void Update(object state)
        {
            ulong speed = 0;
            string adapter = "";
            string[] nameSearches = { "Wireless", "WiFi", "802.11", "Wi-Fi" };
            // The enum value of `AF_INET` will select only IPv4 adapters.
            // You can change this to `AF_INET6` for IPv6 likewise
            // And `AF_UNSPEC` for either one
            foreach (IPIntertop.IP_ADAPTER_ADDRESSES net in IPIntertop.GetIPAdapters(IPIntertop.FAMILY.AF_INET))
            {
                bool containsName = false;
                foreach (string name in nameSearches)
                {
                    if (net.FriendlyName.Contains(name))
                    {
                        containsName = true;
                    }
                }
                if (!containsName) continue;
                speed = net.TrasmitLinkSpeed;
                adapter = net.FriendlyName;
                break;
            }
            
            string temp;
            if (speed == 0)
            {
                temp = "There is currently no Wi-Fi connection";
            }
            else
            {
                temp = string.Format("Current Wi-Fi Speed: {0} Mbps on {1}", (speed / 1000000.0), adapter);
            }
            
            Console.WriteLine(temp);
        }
    }
