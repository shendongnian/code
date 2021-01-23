        public static bool IpIsInRange(string subnet, string ip)
        {
            var splitSubnet = subnet.Split('/');
            var maskBits = 32 - int.Parse(splitSubnet[1]);
            if (maskBits == 32)
            {
                return true;
            }
            var subnetIp = BitConverter.ToInt32(IPAddress.Parse(splitSubnet[0]).GetAddressBytes().Reverse().ToArray(), 0) >> maskBits << maskBits;
            var clientIp = BitConverter.ToInt32(IPAddress.Parse(ip).GetAddressBytes().Reverse().ToArray(), 0) >> maskBits << maskBits;
            return subnetIp == clientIp;
        }
