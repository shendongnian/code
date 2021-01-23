    protected void ButtonRemoveSelectedItem_Click(object sender, EventArgs e)
    {
        int position = 0;
        for (byte i = 0; i < ListBox2.Items.Count; i++)
        { 
            position = ListBox2.SelectedIndex ;
        }
        ListBox2.Items.RemoveAt(position);
    }
