    private void textPasted()
    {
        String input = Clipboard.GetText();
        int l1 = textBoxWithOnPaste1.MaxLength;
        int l2 = textBoxWithOnPaste2.MaxLength;
        int l3 = textBoxWithOnPaste3.MaxLength;
        try
        {
            textBoxWithOnPaste1.Text = input.Substring(0, l1);
            textBoxWithOnPaste2.Text = input.Substring(l1, l2);
            textBoxWithOnPaste3.Text = input.Substring(l2, l3);
        }
        catch (Exception)
        { }
    }
