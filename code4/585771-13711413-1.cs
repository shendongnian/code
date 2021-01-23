    int id = 0;
    foreach (ListViewItem item in listView1.Items)
    {
       if((int)item.Tag == id)
       {
          item.Remove();
          break;
       }
    }
