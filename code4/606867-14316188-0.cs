    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        double d;
        if (!double.TryParse(txt.Text, out d))
        {
            MessageBox.Show("Please enter a valid number");
            return;
        }
        string num = d.ToString();
        string decSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        int numDecPlaces = 0;
        int decSepIndex = num.LastIndexOf(decSeparator);
        if (decSepIndex != -1)
            numDecPlaces = num.Substring(decSepIndex).Length;
        if (numDecPlaces > 2)
        {
            MessageBox.Show("Please enter two decimal places at a maximum");
            return;
        }
    }
