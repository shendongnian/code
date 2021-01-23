    public class MyModelType
    {
        [NotMapped]
        private bool _enableFullValidation;
        [RequiredIf("_enableFullValidation")]
        public string MyNoneRequiredDBField { get; set; }
    }
