        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int outva;
            dataGridView1.ClearSelection();
        
            if (int.TryParse((e.Node.Text), out outva))
            {
                //save=Convert.ToInt16(e.Node.Text);  //not needed
        
                string filterBy;
        
                if (e.Node.Parent != null)
                {
                    filterBy = "GroupId = " + outva;
                }
                else
                {
                    filterBy = "StringId = " outva;
                }
        
                //int row = dataGridView1.Rows.Count; // not needed
        
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = filterBy;
            }
            else 
            {
        
            }
        }
