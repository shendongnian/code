    [MetadataType(typeof(PreviousResultsMetaData))]
    public partial class PreviousResults
    {
        public class PreviousResultsMetaData
        {
            [DisplayName("Class Ranking Score")]
            [Required]
            [Range(0.0, 100.0)]
            public object ClassRankingScore { get; set; }
        }
    }
