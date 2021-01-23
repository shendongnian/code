    public class DeviceByAddressEqualityComparer : IEqualityComparer<IDevice> {
        public bool Equals(IDevice x, IDevice y) {
            if(x==y)
              return true;
            if(x==null||y==null)
              return false;
            return x.Address.Equals(y.Address);
        }
    
        public int GetHashCode(IDevice obj) {
            if(obj == null)
              return 0;
            else
              return obj.Address.GetHashCode();
        }
    }
