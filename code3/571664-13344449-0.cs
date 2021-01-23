    private void buttonMoveToListBox1_Click(object sender, EventArgs e)
    {
        if(listBox1.SelectedIndex != -1)
        {
            listBox2.Add(listBox1.SelectedValue);
            listBox1.Remove(listBox1.SelectedValue);
        }
    }
    
    private void buttonMoveToListBox2_Click(object sender, EventArgs e)
    {
        if(listBox2.SelectedIndex != -1)
        {
            listBox1.Add(listBox2.SelectedValue);
            listBox2.Remove(listBox2.SelectedValue);
        }
    }
