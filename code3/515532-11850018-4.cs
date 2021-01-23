    public class MyViewModel
    {
        [RequiredToBeTrue]
        public bool TermsEligibility { get; set; }
        [RequiredToBeTrue]
        public bool TermsAccurate { get; set; }
        [RequiredToBeTrue]
        public bool TermsIdentityRelease { get; set; }
        [RequiredToBeTrue]
        public bool TermsScoreRelease { get; set; }
 
        ... some other properties that are used in your view
    }
