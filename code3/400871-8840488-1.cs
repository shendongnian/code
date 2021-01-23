    // Wizard user control constructor
    public Wizard(IWizardMovementViewModel viewModel)
    {
        MoveNext += viewModel.WizardMovedNext;
        MoveBack += viewModel.WizardMovedBack;
        Canceled += viewModel.WizardMoveCanceled;
    }
