    public class IPSubnet
    {
        private readonly byte[] _address;
        private readonly int _prefixLength;
        public IPSubnet(string value)
        {
            string[] parts = value.Split('/');
            _address = IPAddress.Parse(parts[0]).GetAddressBytes();
            _prefixLength = Convert.ToInt32(parts[1], 10);
        }
        public bool Contains(string address)
        {
            return this.Contains(IPAddress.Parse(address).GetAddressBytes());
        }
        public bool Contains(byte[] address)
        {
            if (address.Length != _address.Length)
                return false;
            int index = 0;
            int bits = _prefixLength;
            for (; bits >= 8; bits -= 8)
            {
                if (address[index] != _address[index])
                    return false;
                ++index;
            }
            if (bits > 0)
            {
                int mask = (byte)~(255 >> bits);
                if ((address[index] & mask) != (_address[index] & mask))
                    return false;
            }
            return true;
        }
    }
