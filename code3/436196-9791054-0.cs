    private void numericUpDown1_EnabledChanged(object sender, EventArgs e)
    {
       NumericUpDown nud = (NumericUpDown)sender;
       nud.BackColor = nud.Enabled ? Color.Yellow : Color.Red;
    }
