    public sealed class MediaTransportProtocolType
    {
        public static readonly MediaTransportProtocolType RtpAvp =
            new MediaTransportProtocolType("RTP/AVP");
        public static readonly MediaTransportProtocolType RtpSavp =
            new MediaTransportProtocolType("RTP/SAVP");
            public static readonly MediaTransportProtocolType Udp =
            new MediaTransportProtocolType("UDP");
        public static readonly ReadOnlyCollection<MediaTransportProtocolType>
            Values = new ReadOnlyCollection<MediaTransportProtocolType>(
                new MediaTransportProtocolType[] { RtpAvp, RtpSavp, Udp });
            
        private MediaTransportProtocolType(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        
        public static MediaTransportProtocolType Parse(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }
            var comparer = StringComparer.OrdinalIgnoreCase;
            
            if (comparer.Equals(value, RtpAvp.Name))
            {
                return RtpAvp;
            }
            else if (comparer.Equals(value, RtpSavp.Name))
            {
                return RtpSavp;
            }
            else if (comparer.Equals(value, Udp.Name))
            {
                return Udp;
            }
            else if (value.StartsWith("RTP/", StringComparison.OrdinalIgnoreCase))
            {
                // Normally we would throw an exception here, but  future
                // protocols are expected and we must be forward compatible.
                return new MediaTransportProtocolType(name);
            }
            throw new FormatException(
                "The value is not in an expected format. Value: " + value);
        }
    }
