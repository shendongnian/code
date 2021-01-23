    public class Stage
    {
        public string Name { get; set; }
        [Column(TypeName = "bigint")]
        public TimeSpan Span { get; set; }
        public int StageId { get; set; }
    }
