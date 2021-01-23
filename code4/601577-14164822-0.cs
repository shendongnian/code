    var queryStr =
        "SELECT * " +
        "FROM Win32_NetworkAdapterConfiguration " +
        "WHERE IPEnabled = true";
    using (var searcher = new ManagementObjectSearcher(queryStr))
    using (var managementQuery = searcher.Get())
    {
        // convert to LINQ to Objects query
        var query =
            from ManagementObject mo in managementQuery
            orderby Convert.ToUInt32(mo["IPConnectionMetric"])
            select new
            {
                Description          = Convert.ToString(mo["Description"]),
                Index                = Convert.ToString(mo["Index"]),
                MACAddress           = Convert.ToString(mo["MACAddress"]),
                IPAddress            = String.Join(", ", (string[])mo["IPAddress"] ?? new string[0]),
                IPSubnet             = String.Join(", ", (string[])mo["IPSubnet"] ?? new string[0]),
                DefaultIPGateway     = String.Join(", ", (string[])mo["DefaultIPGateway"] ?? new string[0]),
                DNSServerSearchOrder = String.Join(", ", (string[])mo["DNSServerSearchOrder"] ?? new string[0]),
            };
        // grab the fields
        String description = null;
        foreach (var item in query)
        {
            description  = description  ?? item.Description;
            _NICINDEX    = _NICINDEX    ?? item.Index;
            _MACADDRESS  = _MACADDRESS  ?? item.MACAddress;
            _IPADDRESS   = _IPADDRESS   ?? item.IPAddress;
            _IPV6ADDRESS = _IPV6ADDRESS ?? item.IPAddress;
            _SUBNETMASK  = _SUBNETMASK  ?? item.IPSubnet;
            _GATEWAY     = _GATEWAY     ?? item.DefaultIPGateway;
            _DNSSERVER   = _DNSSERVER   ?? item.DNSServerSearchOrder;
            _DNSSECSVR   = _DNSSECSVR   ?? item.DNSServerSearchOrder;
            // check if all fields are set so we can stop
            if (new[] { description, _NICINDEX, _MACADDRESS, _IPADDRESS, _IPV6ADDRESS, _SUBNETMASK, _GATEWAY, _DNSSERVER, _DNSSECSVR }.All(x => x != null))
                break;
        }
    }
