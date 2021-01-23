    public class WizardVm {
       public string Name { get; set; }
       public ICommand QuitCommand { get { /* ommitted */ } }
       public object CurrentStep { get; set; }//raise OnPropertyChanged("CurrentStep"); in your setter!!
    }
    public class WizardStep1Vm {
       public string StepName { get; set; }
       public string StepText {get; set; }
    }
    public class WizardStep2Vm {
       public string StepName { get; set; }
       public string StepText {get; set; }
    }
