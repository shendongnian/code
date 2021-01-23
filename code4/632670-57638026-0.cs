    class myItem {
        string name {get; set;}
        string price {get; set;}
        string desc {get; set;}
    }
    
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
         myItem selected_item = new myItem();
         selected_item.name  = listBox1.SelectedItem.Text;
         Retrieve (selected_item.name);
    }
