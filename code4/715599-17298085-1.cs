    public static class HelperFunctions
    {
        public static string GetRadioButtonValue(this ControlCollection collection)
        {
            foreach (var control in collection)
            {
                if (control is HtmlInputRadioButton)
                {
                    var radioControl = ((HtmlInputRadioButton)control);
                    if (radioControl.Checked)
                    {
                        return radioControl.Value;
                    }
                }
            }
    
            //If no item has been clicked or no Input Radio controls are present we return an empty string
            return String.Empty;
        }
    }
