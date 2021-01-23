    /// <summary>
    /// Hides the New User Control.
    /// </summary>
    private void HideNewUserControl()
    {
         NewUserControl.Visibility = Visibility.Hidden;
         DiagramControl.Visibility = Visibility.Visible;
         enableButtons();
         if (family.Current != null)
            DetailsControl.DataContext = family.Current;
    }
    /// <summary>
    /// Shows the New User Control.
    /// </summary>
    private void ShowNewUserControl()
    {
            HideFamilyDataControl();
            HideDetailsPane();
            DiagramControl.Visibility = Visibility.Collapsed;
            WelcomeUserControl.Visibility = Visibility.Collapsed;
            if (PersonInfoControl.Visibility == Visibility.Visible)
                ((Storyboard)this.Resources["HidePersonInfo"]).Begin(this);
            NewUserControl.Visibility = Visibility.Visible;
            NewUserControl.ClearInputFields();
            NewUserControl.SetDefaultFocus();
            ... //Removed for brevity
        }
