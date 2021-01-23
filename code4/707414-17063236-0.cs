    private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text = "Edit User")
            {
                label2.Visible = true;
    
            }
            else
            {
                label2.Visible = false;
            }
    
        }
