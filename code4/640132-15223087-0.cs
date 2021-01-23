    StringCollection kolekce = new StringCollection();
    foreach (ListItem i in ListBox1.Items)
    {
        kolekce.Add(i.Text + "|" + i.Value);
    }
    Session["Session"] = kolekce;
