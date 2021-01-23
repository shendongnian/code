    for(int i = 1; i <= 10; i++)
    {
        string id = i.ToString();
        string text = "Foo#" + i;
        SupplierListBox.Items.Add(new ListItem(text, id));
    }
