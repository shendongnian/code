    public static class MaskedTextBoxExtension {
       public static void SetValue(this MaskedTextBox t, double value){
          Text = value.ToString(value >= 0 ? " 0.00" : "-0.00");
       }
    }
    //I recommend setting this property of your MaskedTextBox to true
    yourMaskedTextBox.HidePromptOnLeave = true;//this will hide the prompt (which looks ugly to me) if the masked TextBox is not focused.
