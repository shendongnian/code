    private void checkBox_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = sender as CheckBox;
        if (checkBox.Checked)
            foreach (var other in Controls.OfType<CheckBox>().Where(c => c != checkBox))
                other.Checked = false;
    }
