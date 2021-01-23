    {
        setupMasterToolStripMenuItem.Click += ToolStripMenuItem_Click;
        setupUserToolStripMenuItem.Click += ToolStripMenuItem_Click;
    }
    ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem toolStripMenuItem = ((ToolStripMenuItem) sender);
        // may be like this
        // or you can check setupUser/setupMasterToolStripMenuItem 
        // is equal to toolStripMenuItem or check 'Tag' or them
        UserMenu += toolStripMenuItem .Text;
         
        UserRights=ValidateUser(UserMenu);
        if (UserRights == 1)
        {
            frmDataReader frmDR = new frmDataReader();
            frmDR.Show();
        }
        else
        {
            MessageBox.Show("No Permission");
        }
    }
