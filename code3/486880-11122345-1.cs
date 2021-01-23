    ContextMenu cm = new ContextMenu();
    void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            cm.MenuItems.Clear();
            if (e.ColumnIndex == 0)
            {
                var mi = new MenuItem("C:\temp");
                mi.MenuItems.Add(mi);
                // handle menu item click event here [as required]
                mi.Click += OnMenuItemClick;
                cm.MenuItems.Add(0, mi);
                var bounds = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                if (sender != null)
                {
                    cm.Show(sender as DataGridView, new Point(bounds.X, bounds.Y));
                }
            }
        }
    }
     void OnMenuItemClick(object sender, EventArgs e)
     {
          MessageBox.Show(((MenuItem)sender).Text);
     }
