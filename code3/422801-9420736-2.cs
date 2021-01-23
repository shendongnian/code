    interface IWizardInfo
    {
        int someIntInfo { get set; }
        string someStringInfo { get set; }
        ...
    }
    interface IStep
    {
        void Process(IWizardInfo info);
    }
    class Wizard
    {
         IWizardInfo _info = ....;
         IStep[] _steps = new IStep[] { new Step1(), new Step2(), ... };
         int _currentStep;
        
         void ProcessCurrentStep()
         {
             _steps[_currentStep++].Process(_info);
         }
    }
