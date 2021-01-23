    private void CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox) sender;
        if (cb.Checked)
        {
            foreach (CheckBox control in cb.Parent.Controls)
            {
                if (control != cb)
                    control.Checked = false;
            }
        }
    }
