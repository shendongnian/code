    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.SelectedItem != null)
        {    
            textBox2.Clear();
            listBox2.Items.Clear();
            string[] p = Directory.GetFiles(textBoxDir.Text, listBox1.SelectedItem.ToString(), SearchOption.AllDirectories);
            foreach (string open in p) 
             ...... }
        }
    }
