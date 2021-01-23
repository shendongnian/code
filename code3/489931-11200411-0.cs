    public class Vote()
    {
         public VoteType VoteSelectType { get; set; }
    }
    
    public enum VoteType
    {
        [Display(Name = "Enter Text Here")]
        unanimous = 1,
        [Display(Name = "Enter Text Here")]
        threequatervote = 2,
        [Display(Name = "Enter Text Here")]
        simplymajority = 3
    }
