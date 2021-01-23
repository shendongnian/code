    private void Form1_Load(object sender, EventArgs e)
    {
        listView1.MouseUp += new MouseEventHandler(listView1_MouseClick);
        
    }
    
    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
        string id = "xxx";//extra value
    
        if (e.Button == MouseButtons.Right)
        {
            if (listView1.FocusedItem != null && listView1.FocusedItem.Bounds.Contains(e.Location) == true)
            {
                ContextMenu m = new ContextMenu();
                MenuItem cashMenuItem = new MenuItem("編輯");
                cashMenuItem.Click += delegate (object sender2, EventArgs e2) {
                    ActionClick(sender, e, id);
                };// your action here 
                m.MenuItems.Add(cashMenuItem);
                MenuItem cashMenuItem2 = new MenuItem("-");
                m.MenuItems.Add(cashMenuItem2);
                MenuItem delMenuItem = new MenuItem("刪除");
                delMenuItem.Click += delegate (object sender2, EventArgs e2) {
                    DelectAction(sender, e, id);
                };// your action here
                m.MenuItems.Add(delMenuItem);
                m.Show(listView1, new Point(e.X, e.Y));
            }
        }
    }
    
    private void DelectAction(object sender, MouseEventArgs e, string id)
    {
        ListView ListViewControl = sender as ListView;
        foreach (ListViewItem eachItem in ListViewControl.SelectedItems)
        {
            // you can use this idea to get the ListView header's name is 'Id' before delete
            Console.WriteLine(GetTextByHeaderAndIndex(ListViewControl, "Id", eachItem.Index) );
            ListViewControl.Items.Remove(eachItem);
        }
    }
    private void ActionClick(object sender, MouseEventArgs e, string id)
    {
        //id is extra value when you need or delete it
        ListView ListViewControl = sender as ListView;
        foreach (ListViewItem tmpLstView in ListViewControl.SelectedItems)
        {
            Console.WriteLine(tmpLstView.Text);
        }
    
    }
    public static string GetTextByHeaderAndIndex(ListView listViewControl, string headerName, int index)
    {
        int headerIndex = -1;
        foreach (ColumnHeader header in listViewControl.Columns)
        {
            if (header.Name == headerName)
            {
                headerIndex = header.Index;
                break;
            }
        }
        if (headerIndex > -1)
        {
            return listViewControl.Items[index].SubItems[headerIndex].Text;
        }
        return null;
    }
