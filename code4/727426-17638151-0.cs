    private void textBox1_Enter(object sender, EventArgs e)
    {
        System.Globalization.CultureInfo TypeOfLanguage = new System.Globalization.CultureInfo("ms-MY");
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
    }
    private void textBox1_Leave(object sender, EventArgs e)
    {
        System.Globalization.CultureInfo TypeOfLanguage = new System.Globalization.CultureInfo("en-us");
        InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
    }
