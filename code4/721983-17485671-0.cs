    [ProtoContract]
    public class PointDto
    {
        [ProtoMember(1)] public int X { get; set; }
        [ProtoMember(2)] public int Y { get; set; }
    
        public static implicit operator System.Drawing.Point(PointDto value)
        {
            return value == null
                ? System.Drawing.Point.Empty
                : new System.Drawing.Point(value.X, value.Y);
        }
        public static implicit operator PointDto(System.Drawing.Point value)
        {
            return new PointDto { X = value.X, Y = value.Y };
        }
    }
