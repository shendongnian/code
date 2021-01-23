    public class filesdetail : IEquatable<filesdetail>
    {
        public string truckno { get; set; }
        public string deliveryno { get; set; }
        public bool Equals(filesdetail other)
        {
            return other != null &&
                    Equals(truckno, other.truckno) &&
                    Equals(deliveryno, other.deliveryno);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as filesdetail);
        }
        public override int GetHashCode()
        {
            var trucknoHash = truckno == null ? 0 : truckno.GetHashCode();
            var deliverynoHash = deliveryno == null ? 0 : deliveryno.GetHashCode();
            return (trucknoHash*397) ^ deliverynoHash;
        }
    }
