                if (!is_listview) //treeview item 
                {
                    //get a text of a dragged item 
                    string str = e.Data.GetData(DataFormats.Text).ToString(); 
                    //get information about hovered item 
                    ListViewHitTestInfo hit_info = listView1.HitTest(listView1.PointToClient(new Point(e.X, e.Y))); 
                    //check position - must be on an item 
                    if (hit_info.Location == ListViewHitTestLocations.None) return; 
                    ListViewItem prev_item = hit_info.Item; 
                    ListViewGroup group = prev_item.Group;
                    int idx = group.Items.IndexOf(prev_item);
                    //create a new key 
                    Guid key = Guid.NewGuid(); 
                    string item_key = key.ToString(); 
                    //create a new item 
                    //option 1 
                    List<ListViewItem> list = new List<ListViewItem>();
                    while(group.Items.Count > 0)
                    {
                        ListViewItem lvi = group.Items[0];
                        listView1.Items.Remove(lvi);
                        list.Add(lvi);
                    }
                    group.Items.Clear();
                    ListViewItem item = new ListViewItem(str, "");
                    item.Name = item_key;
                    list.Insert(idx, item);
                    foreach (ListViewItem i in list)
                    {
                        listView1.Items.Add(i);
                        group.Items.Add(i);
                    }
                }
