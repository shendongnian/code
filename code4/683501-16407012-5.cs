    void fill_listbox()
    {
        char[] values = txtContent.Text.Text.Replace(" ", string.Empty).ToCharArray();
        foreach (char value in values)
        {
            listBox1.Items.Add(value);
        }
    }
