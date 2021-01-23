    private void listView1_MouseDown(object sender, MouseEventArgs e)
    {
        bool match = false;
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Bounds.Contains(new Point(e.X, e.Y)))
                {
                    MenuItem[] mi = new MenuItem[] { new MenuItem("Hello"), new MenuItem("World"), new MenuItem(item.Name) };
                    listView1.ContextMenu = new ContextMenu(mi);
                    match = true;
                    break;
                }
            }
            if (match)
            {
                listView1.ContextMenu.Show(listView1, new Point(e.X, e.Y));
            }
            else
            {
                //Show listViews context menu
            }
        }
            
    }
