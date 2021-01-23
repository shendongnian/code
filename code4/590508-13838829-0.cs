    private string GetControlValue(string controlId)
    {
        var control = FindControl(controlId);
        if(control is ITextControl)
        {
            return ((ITextControl) control).Text; // works also for the RadComboBox since it returns the currently selected item's text
        }
        else if(control is ICheckBoxControl)
        {
            return ((ICheckBoxControl)control).Checked.ToString();
        }
        else
        {
            return null;
        }
    }
