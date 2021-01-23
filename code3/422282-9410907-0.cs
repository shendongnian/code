        ListBox mylist = new ListBox();
        mylist.Items.Add(new ListItem("Tahir", "Tahir"));
        Session["ITEM"] = mylist;
        foreach (ListItem Item in ((ListBox)(Session["ITEM"])).Items)
        {          
            mylist.Items.Add(new ListItem(Item.Text, Item.Value));
        }
