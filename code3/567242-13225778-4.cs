    void TextBox_LostFocus(object sender, EventArgs e)
    {
        var tb = sender as TextBox;
        if (tb != null)
        {
            // modify tb.Text here, possibly like this...
            tb.Text = String.Format("{0:C}", Decimal.Parse(tb.Text));
        }
    }
