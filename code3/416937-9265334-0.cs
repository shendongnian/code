    class DeviceAddressEqualityComparer : IEqualityComparer<Device> {
        public bool Equals(Device x, Device y) {
            Contract.Requires(x != null);
            Contract.Requires(y != null);
            return x.Address.Equals(y.Address);
        }
        public int GetHashCode(Device obj) {
            Contract.Requires(obj != null);
            return obj.Address.GetHashCode();
        }
    }
            
