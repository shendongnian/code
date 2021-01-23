    public struct NtpHeader
    {
        private readonly ushort bits;
        // Creates a header from a portion of a byte array, e.g
        // given a complete packet and the index within it
        public NtpHeader(byte[] data, int index)
        {
            bits = (ushort) (data[index] + (data[index] << 8));
        }
        public NtpHeader(int leapIndicator, int versionNumber,
                         int mode, int stratum)
        {
            // TODO: Validation
            bits = (ushort) (leapIndicator |
                             (versionNumber << 2) |
                             (mode << 5) |
                             (stratum << 8));
        }
        public int LeapIndicator { get { return bits & 3; } }
        public int VersionNumber { get { return (bits >> 2) & 7; } }
        public int Mode { get { return (bits >> 5) & 7; } }
        public int Stratum { get { return bits >> 8; } }
    }
