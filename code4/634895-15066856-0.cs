    foreach (ListViewItem i in listView2.SelectedItems)
    {
       string userBody = body;
       ...
       userBody = userBody.Replace("%name%", SkypeUser.Users[Convert.ToInt32(ID[1])].Name);
       ...
    }
