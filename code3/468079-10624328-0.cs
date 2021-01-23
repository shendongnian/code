    public class Fees
    {
        private decimal permit;
        private decimal planReview;
        private decimal surcharge;
        public decimal permitFee
        {
            set { permit = Math.Round(value, 2); }
            get { return permit; }
        }
        public decimal planReviewFee 
        {
            set { planReview = Math.Round(value, 2); }
            get { return planReview; } 
        }
        public decimal surchargeFee 
        {
            set { surcharge = Math.Round(value, 2); }
            get { return surcharge; } 
        }
        public decimal totalFee 
        { 
            get { return permitFee + planReviewFee + surchargeFee; } 
        }
    }
