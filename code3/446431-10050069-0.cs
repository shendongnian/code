      private void createGraphicsColumn()
        {
            Icon treeIcon = new Icon(this.GetType(), "tree.ico");
            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Image = treeIcon.ToBitmap();
            iconColumn.Name = "Tree";
            iconColumn.HeaderText = "Nice tree";
            dataGridView1.Columns.Insert(2, iconColumn);
        }
