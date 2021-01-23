    while (dr.Read())
    {
        // If you don't do this, you are just changing the same
        // ToolStripMenuItem object all the time.
        menu = new ToolStripMenuItem();
        menu.Tag = dr["ModuleId"].ToString();
        menu.Text = dr["ModuleName"].ToString();
        menu.Name = dr["pagename"].ToString();
        menu.ToolTipText = dr["pagename"].ToString();
        menuStrip1.Items.Add(menu);
        menuStrip1.Show();
    }
