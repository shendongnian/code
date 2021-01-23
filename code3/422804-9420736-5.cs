    class Step1 { public Step1(AllSteps steps) { steps.Step1 = this; } ... }
    class Step2 { public Step2(AllSteps steps) { steps.Step2 = this; } ... }
    class Step3 { public Step3(AllSteps steps) { steps.Step3 = this; } ... }
    
    class AllSteps
    {
         public Step1 Step1 { get; set; }
         public Step2 Step2 { get; set; }
         public Step3 Step3 { get; set; }
    }
