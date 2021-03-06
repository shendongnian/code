    YourFormName.Controls.OfType<TextBox>().ToList().ForEach(textBox => textBox.Clear());
    private void ClearTextBoxes(Control control)
    {
        foreach(Control childControl in control.Controls)
        {
             TextBox textbox = childControl as TextBox;
             if(textbox != null)
                textbox.Text = string.Empty;
             else if(childControl.Controls.Count > 0)
                 ClearTextBoxes(childControl);//Recursive call here
        }
    }
