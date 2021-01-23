    private void button2_Click(object sender, EventArgs e)
    {
        // SelectedIndex returns -1 if nothing is selected
        if(listBox2.SelectedIndex != -1)
        {
            if( listBox2.SelectedItem.ToString().Equals("Test") )
            {
                picturebox.Image = null;
            }
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }
    }
