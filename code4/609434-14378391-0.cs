    DataGridViewImageColumn imageColoumn = new DataGridViewImageColumn();
            imageColoumn.HeaderText = "Img";
            imageColoumn.Image = null;
            imageColoumn.Name = "DataPic";
            imageColoumn.Width = 150;
            dataGridView1.Columns.Add(imageColoumn);
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewImageCell cell = row.Cells[1] as DataGridViewImageCell;
                cell.Value = (System.Drawing.Image)Properties.Resources.logo;
            }
