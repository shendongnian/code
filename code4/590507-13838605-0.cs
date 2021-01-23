    private string GetControlValue(string controlId)
    {
        var control = FindControl(controlId);
        var radTextBox = control as RadTextBox;
        if (radTextBox != null)
        {
            return radTextBox.Text;
        }
        
        var radComboBox = control as RadComboBox;
        if (radComboBox != null)
        {
            return radComboBox.SelectedValue;
        }
        var checkBox = control as CheckBox;
        if (checkBox != null)
        {
            return checkBox.Checked.ToString();
        }
        return null;
    }
