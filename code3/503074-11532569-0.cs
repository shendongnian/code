    class JobApplicationViewModel
    {
        public Guid ApplicationGuid { get; set; }
        public StepOne Step1 { get; set; }
        public StepTwo Step2 { get; set; }
        public int CurrentStep { get; set; }
    }
