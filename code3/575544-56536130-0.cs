    private void Form1_Load(object sender, EventArgs e)
    {
        listView1.MouseDown += new MouseEventHandler(listView1_MouseClick);
        
    }
    
    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
        string id = "xxx";//extra value
    
        if (e.Button == MouseButtons.Right)
        {
            try
            {
                // To avoid an exception if the list have no items
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
                        ActionClick(sender, e, id);
                    };// your action here
                    m.MenuItems.Add(delMenuItem);
                    m.Show(listView1, new Point(e.X, e.Y));
    
                }
    
            }
            catch
            {
    
            }
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
