    private void ChangeValue(object sender, EventArgs e)
    {
        double text20, text19;
        if (
            !double.TryParse(TextBox19.Text, out text19) ||
            !double.TryParse(TextBox20.Text, out text20)
        )
        {
            TextBox21.Text = "Can't calculate.";
            return;
        }
        TextBox21.Text = ( text19 - text20 ).ToString();
    }
