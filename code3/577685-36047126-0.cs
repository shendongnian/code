    public class RemoteDevice: IEquatable<RemoteDevice>
    {
        private readonly int id;
        public RemoteDevice(int uuid)
        {
            id = id
        }
        public int GetId
        {
            get { return id; }
        }
        // ...
        public bool Equals(RemoteDevice other)
        {
            if (this.GetId == other.GetId)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return id;
        }
    }
