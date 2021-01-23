    private void button1_Click(object sender, EventArgs e)
    {
        if (!listBox.Items.Exists) // Random Idea which doesnt work
        {
        listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
        }
    }
