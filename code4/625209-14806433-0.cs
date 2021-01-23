     DataTable dt = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            //put some data into a table
            int[,] time = new int[,] { { 0, 4, 1 }, { 1, 5, 2 }, { 15, 10, 3 } };
        
            dt.Columns.Add("x");
            dt.Columns.Add("y");
            dt.Columns.Add("z");
            for (int i = 0; i < 3; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = time[i, 0];
                dr[1] = time[i, 1];
                dr[2] = time[i, 2];
                dt.Rows.Add(dr);
            }
           dataGridView1.DataSource = dt;
             
        }
    
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ShowCellToolTips = true;
          
            Point loc = dataGridView1.CurrentCellAddress;
            if (loc.X == 0)
            {
                dataGridView1.CurrentCell.ToolTipText = String.Format("{0} ",
                    dt.Rows[loc.Y][loc.X + 1].ToString() + dt.Rows[loc.Y][loc.X + 2].ToString());
            }
        }
