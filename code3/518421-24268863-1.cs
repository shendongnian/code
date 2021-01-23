    public partial class JobPosting
    {
        public int PositionRowId { get; set; }
        public System.Guid PositionRelatedGuid { get; set; }
    
        public struct ColumnName 
        {
            public const string PositionRowId = "PositionRowId";
            public const string PositionRelatedGuid = "PositionRelatedGuid";
        }
    }
