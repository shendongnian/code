    public class RemoteDevice
    {
        public Guid UUID { get; set; }
    
        public override bool Equals(object obj)
        {
            RemoteDevice other = obj as RemoteDevice;
            if (other == null) return false;
            return UUID.Equals(other.UUID);
        }
    
        public override int GetHashCode()
        {
            return UUID.GetHashCode();
        }
    }
