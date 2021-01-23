    void buttonRemove_Click(object sender, EventArgs e) 
    {
        string matchcode = TextBox1.Text;
    
        ListItem item = this.ListBox1.Items.FindByText(matchcode);
    
        if (item != null)
        {
            //found
            this.ListBox1.Items.Remove(item);
        }
        else
        {
            //not found
            MessageBox.Show("is not found");
        }
    }
