     protected void Wizard1_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
      {
        e.Cancel = !ValidateWizardStep(e.NextStepIndex);
      }
    
      protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
      {
        e.Cancel = !ValidateWizardStep(e.NextStepIndex);
      }
