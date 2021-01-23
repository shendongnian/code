    public void ResetFields(Control.ControlCollection Controls)
    {
    foreach(Control control in Controls)
    {
       if (control is TextBox)
       {
          control.Text = string.Empty;
       }
       if (control is NumericUpDown)
       {
          NumericUpDown updown = control as NumericUpDown;
          updown.Value = 3;
       }
    
       if (control.Controls.Count > 0)
       {
          this.ResetFields(control.Controls);
       }
    }
    }
