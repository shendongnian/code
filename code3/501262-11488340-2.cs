    private bool AtLeastOnePlatypusSelected()
    {
        string DefaultPlatypusValue = "<--Select-->";
        return (string)((ComboBoxItem)cmbxWeek1.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek2.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek3.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek4.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek5.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek6.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek7.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek8.SelectedValue).Content != DefaultPlatypusValue ||
               (string)((ComboBoxItem)cmbxWeek9.SelectedValue).Content != DefaultPlatypusValue;
    } 
 
