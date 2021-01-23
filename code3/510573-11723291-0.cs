    public class RouteIdentity
    {
        public string RouteId { get; set; }
        public string RegionId { get; set; }
        public DateTime RouteDate { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(RouteIdentity))
            {
                return false;
            }
            RouteIdentity other = (RouteIdentity) obj;
            
            return Equals(other.RouteId, RouteId) && 
                   Equals(other.RegionId, RegionId) && 
                   other.RouteDate.Equals(RouteDate);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (RouteId != null ? RouteId.GetHashCode() : 0);
                result = (result * 397) ^ (RegionId != null ? RegionId.GetHashCode() : 0);
                result = (result * 397) ^ RouteDate.GetHashCode();
                return result;
            }
        }
    }
