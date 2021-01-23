            int[,] time = new int[5, 2] { { 0, 4 }, { 1, 5 }, { 15, 10 }, { 3, 4 }, { 0, 2 } };
            
            DataTable dt = new DataTable();
            dt.Columns.Add("x", System.Type.GetType("System.Int32"));
            dt.Columns.Add("y", System.Type.GetType("System.Int32"));
            for (int i = 0; i < time.Length / 2; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = time[i, 0];
                dr[1] = time[i, 1];
                dt.Rows.Add(dr);
            }
            dt.DefaultView.Sort = "x" + " " + "ASC";
            dt = dt.DefaultView.ToTable();
            
