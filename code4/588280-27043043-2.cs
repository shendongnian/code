    public static class PhysicalAddressExtensions
    {
        public static string ToString(this PhysicalAddress address, string separator)
        {
            return string.Join(separator, address.GetAddressBytes()
                                                 .Select(x => x.ToString("X2")))
        }
    }
