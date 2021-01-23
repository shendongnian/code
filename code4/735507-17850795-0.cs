        foreach (Control control in this.Controls)
        {
            if (control.GetType() == typeof(TextBox))
            {
                if ((e.KeyCode == Keys.Back && String.IsNullOrWhiteSpace(control.Text)))
                {
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                }
            }
        }
