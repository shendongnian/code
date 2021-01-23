    public class Fees {  
    private int permit;  
    private int planReview;  
    private int surcharge;  
    public decimal permitFee { set { permit = (int) (value * 100); }; 
                               get { return permit / 100; } }  
    public decimal planReviewFee { set { planReview = (int) (value * 100); } 
                                   get { return planReview / 100; } }
    public decimal surchargeFee { set { surcharge = (int) (value * 100); } 
                                  get { return surcharge / 100; } }
    public decimal totalFee { get { return permitFee + planReviewFee + surchargeFee; } }  }  }
