    public sealed class MediaTransportProtocolType
    {
        public static readonly MediaTransportProtocolType RtpAvp =
            new MediaTransportProtocolType("RTP/AVP");
        public static readonly MediaTransportProtocolType RtpSavp =
            new MediaTransportProtocolType("RTP/SAVP");
            public static readonly MediaTransportProtocolType Udp =
            new MediaTransportProtocolType("UDP");
            
        private MediaTransportProtocolType(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        
        public static MediaTransportProtocolType Parse(string name)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            
            if (comparer.Equals(name, RtpAvp.Name))
            {
                return RtpAvp;
            }
            else if (comparer.Equals(name, RtpSavp.Name))
            {
                return RtpSavp;
            }
            else if (comparer.Equals(name, Udp.Name))
            {
                return Udp;
            }
            
            // Normally we would throw an exception here, but  future
            // protocols are expected and we must be forward compatible.
            return new MediaTransportProtocolType(name);
        }
    }
