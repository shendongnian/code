    public partial class PartCrossReference
    {
        public int SourcePartId { get; set; }
        public int TargetPartId { get; set; }
        public string CrossType { get; set; }
        public string Source { get; set; }
        public virtual Part Part { get ; set; }
        public virtual Part Part1 { get ; set; }
    }
    ClassExtend:("^/partial/*").Generate();
