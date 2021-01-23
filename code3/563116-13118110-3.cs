    public class ICD_Map2 : IEquatable<ICD_Map2>
    {
        public ICD_Map2(string callType, string destination) {
            CallType = callType;
            Destination = destination;
        }
        public override int GetHashCode() {
            int result = 17;
            result = -13 * result +
                (CallType == null ? 0 : CallType.GetHashCode());
            result = -13 * result +
                (Destination == null ? 0 : Destination.GetHashCode());
            return result;
        }
        public override bool Equals(object other) {
            return Equals(other as ICD_Map2);
        }
        public bool Equals(ICD_Map2 other) {
            if(other == null) return false;
            if(other == this) return true;
            return CallType == other.CallType && Destination == other.Destination;
        }
        public string CallType {get; private set; }
        public string Destination{get; private set;} 
    }
