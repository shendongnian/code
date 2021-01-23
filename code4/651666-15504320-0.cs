    private void ChangeXRLabels(Control control)
    {
        foreach(Control childControl in control.Controls)
        {
             XRLabel label = childControl as XRLabel;
             if(label != string.Empty)
                label.Text = "Your Text Value goes Here";
             else if(childControl.Controls.Count > 0)
                 ChangeXRLabels(childControl);
        }
    }
