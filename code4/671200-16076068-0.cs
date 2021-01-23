    [ProtoContract]
    public class MutablePoint {
        [ProtoMember(1)] public double X { get; set; }
        [ProtoMember(2)] public double Y { get; set; }
    
        public static implicit operator MutablePoint(ImmutablePoint value) {
            return value == null ? null : new MutablePoint {X=value.X, Y=value.Y};
        }
        public static implicit operator ImmutablePoint(MutablePoint value) {
            return value == null ? null : new ImmutablePoint(value.X, value.Y);
        }
    }
