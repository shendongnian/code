      public class Segment
    {
        public System.Guid Id { get; set; }
        public System.Guid NetworkId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int SourceIndex { get; set; }
        public int TargetIndex { get; set; }
        public bool IsInitialized { get; set; }
        public int NeighborNodeDistance { get; set; }
        public string TrackName { get; set; }
        public bool IsTrackNameFixed { get; set; }
        public byte[] GeometryParameters { get; set; }
        public Nullable<System.Guid> SourceNodeId { get; set; }
        public Nullable<System.Guid> TargetNodeId { get; set; }
        public double Length { get; set; }
        public virtual Network Network { get; set; }
    }
