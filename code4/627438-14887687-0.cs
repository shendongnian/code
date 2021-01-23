        ToolStripMenuItem menu;
    
        private void InitContextMenus()
        {
          menu = new ToolStripMenuItem(">> Create Menu <<");
          menu.Click += menu_Click;
          ctMenu.Items.Add(menu);
        }
    
        void menu_Click(object sender, EventArgs e)
        {
          frmCreateMenu objCreateMenu = new frmCreateMenu();
          objCreateMenu.ShowDialog(this);
          if (objCreateMenu.DialogResult == System.Windows.Forms.DialogResult.OK)
          {
            ToolStripMenuItem subMenu = new ToolStripMenuItem();
            subMenu.Text = objCreateMenu.txtName.Text;
            subMenu.Click += (subSender, subEventArgs) =>
            {
              Process.Start(objCreateMenu.txtStart.Text);
            };
    
            menu.DropDownItems.Add(subMenu);
          }
    }
