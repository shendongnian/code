    private void Form1_Load(object sender, EventArgs e)
    {
        checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
    }
    
    private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.NewValue == CheckState.Unchecked)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }
    }        
    private void button1_Click_1(object sender, EventArgs e)
    {
        if (checkedListBox1.SelectedIndex > -1)
        {
            // set the data on text box
        }
    }
