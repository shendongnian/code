    public class EstimateDetailsModel
    {
        public int EstimateID { get; set; }
    
        public IEnumerable<EstimateDetailsModel> EstimateDetails
        {
            return Repository.GetEstimateDetails(this.EstimateID);
        }
    }
