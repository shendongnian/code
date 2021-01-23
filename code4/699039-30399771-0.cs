    public static string GetRadioValue(ControlCollection controls, string groupName)
    {
       var selectedRadioButton = controls.OfType<RadioButton>().FirstOrDefault(rb => rb.GroupName == groupName && rb.Checked);
       return selectedRadioButton == null ? string.Empty : selectedRadioButton.Attributes["Value"];
    }
