    private void label_Click(object sender, EventArgs e) { ToggleTextColor((Label)sender); }
    private void ToggleTextColor(Control control)
    {
        var currentColor = control.ForeColor;
        control.ForeColor = currentColor == Color.Red ? Color.Black : Color.Red;
    }
