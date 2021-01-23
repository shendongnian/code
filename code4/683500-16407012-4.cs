    private void ShowResult(Result result)
    {
       currentResult = result;
       txtBarcodeFormat.Text = result.BarcodeFormat.ToString();
       txtContent.Text = result.Text;
       fill_listbox();
    }
    void fill_listbox()
    {
        char[] values = txtContent.Text.Text.ToCharArray();
        foreach (char value in values)
        {
            if (value == ' ') { 
                continue;
            }
            listBox1.Items.Add(value);
        }
    }
