    class WizardStepVm : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private string m_stepName;
        public string StepName {
          get {
            return m_stepName;
          }
          set {
            m_stepName = value; 
            NotifyPropertyChanged("StepName");
          }
        }
        /* etc... */
    }
 
