    public class EstimateDetailsModel: List<EstimateDetailsModel.EstimateDetail>
    {
        public class EstimateDetail
        {
            public string dma { get; set; }
            public string callsign { get; set; }
            public string description { get; set; }
        }
    }
