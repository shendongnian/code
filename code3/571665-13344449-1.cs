    private void buttonMoveToListBox1_Click(object sender, EventArgs e)
    {
        if(listBox1.SelectedIndex != -1)
        {
            listBox2.Items.Add(listBox1.SelectedValue);
            listBox1.Items.Remove(listBox1.SelectedValue);
        }
    }
    
    private void buttonMoveToListBox2_Click(object sender, EventArgs e)
    {
        if(listBox2.SelectedIndex != -1)
        {
            listBox1.Items.Add(listBox2.SelectedValue);
            listBox2.Items.Remove(listBox2.SelectedValue);
        }
    }
