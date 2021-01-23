    public interface IWizardMovementViewModel
    {
        void WizardMovedNext(object sender, EventArgs e);
        void WizardMovedBack(object sender, EventArgs e);
        void WizardMoveCanceled(object sender, EventArgs e);
    }
