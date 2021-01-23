    void fill_listbox()
    {
        string item = txtContent.Text;
        if(!listBox.Items.Contains(item))
        {
            listBox1.Items.Add(item);
        }
        textBox1.Text = listBox1.Items.Count.ToString();
    }
