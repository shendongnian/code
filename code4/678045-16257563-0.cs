        [ProtoContract]
        [ProtoInclude(2, typeof(SerializableGeoCoordinate))]
        public class SerializablePointF2D
        {
            [ProtoMember(1)]
            public double[] Values { get; set; }
            public static implicit operator SerializablePointF2D(PointF2D value)
            {
                if (value == null) return null;
                var geoCoordinate = value as GeoCoordinate;
                if (geoCoordinate != null) return new SerializableGeoCoordinate
                {
                    Values = geoCoordinate.ToArrayCopy(),
                };
                return new SerializablePointF2D {Values = value.ToArrayCopy()};
            }
            public static implicit operator PointF2D(SerializablePointF2D value)
            {
                if (value == null) return null;
                var geoCoordinate = value as SerializableGeoCoordinate;
                if (geoCoordinate != null)
                {
                    return new GeoCoordinate(geoCoordinate.Values);
                }
                return new PointF2D (value.Values );
            }
        }
        [ProtoContract]
        public class SerializableGeoCoordinate:SerializablePointF2D
        {
        }
