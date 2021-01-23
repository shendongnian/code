    private void button1_Click(object sender, EventArgs e)
        {
            if (!ListBox.Items.Contains(listBox1.SelectedItem)) // Random Idea which doesnt work
            {
            listBox2.Items.Add(listBox1.SelectedItem);
            }
    
        }
