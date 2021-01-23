    TreeNode node = treeView1.SelectedNode;
            if (node.Text.Contains("XP"))
            {                
                TextBox one = new TextBox();
                Panel i = new Panel();
                i.Dock = DockStyle.Right;
                i.BackColor = Color.Black;
                i.Controls.Add(one);
                i.Show();
                TreeFrm.ActiveForm.Controls.Add(i);               
                
            }
