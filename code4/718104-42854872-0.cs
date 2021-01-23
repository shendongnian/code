            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.Name = "AirplaneImage";
            iconColumn.HeaderText = "Airplane Image";
            dataGridView1.Columns.Insert(5, iconColumn);
            for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
            {
                Bitmap bmp = new Bitmap(Application.StartupPath + "\\Data\\AirPlaneData\\" + dt.Rows[row][4]);
                ((DataGridViewImageCell)dataGridView1.Rows[row].Cells[5]).Value = bmp;
            }
