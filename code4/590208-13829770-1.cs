    public void CheckCheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = sender as CheckBox;
        if (checkbox != null)
        {
            ((Panel)checkbox.Parent).Visible = !checkbox.Checked;  // replace this with your panel
        }
    }
