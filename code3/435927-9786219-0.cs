    public string TBName = "";
    private void txtResult_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (TBName != ((TextBox)sender).Name)
        {
            ((TextBox)sender).SelectionStart = 0;
            ((TextBox)sender).SelectionLength = 0;
            TBName = ((TextBox)sender).Name;
        }
    }
