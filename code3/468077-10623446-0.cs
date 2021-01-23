    public class Fees {
     private integer permit;
     private integer planReview;
     private integer surcharge;
     public decimal permitFee { set { permit = value * 100; }; get { return permit / 100; } }
     public decimal planReviewFee { set { planReview = value * 100; } get { return planReview / 100; } }     
     public decimal surchargeFee { set { surcharge = value * 100; } get { return surcharge / 100; } }
     public decimal totalFee { get { return permitFee + planReviewFee + surchargeFee; } } 
    } 
