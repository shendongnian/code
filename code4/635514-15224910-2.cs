    protected void addNewItems_Click(object sender, EventArgs e)
    {
        string[] n1 = newItemsForAbc.Text.Split(';');
        string[] n2 = newItemsForDef.Text.Split(';');
        foreach(string i in n1)
        {
             abc.Items.Add(new ListItem(i, i));
        }
        foreach(string i in n2)
        {
             def.Items.Add(new ListItem(i,i));
        } 
    }
