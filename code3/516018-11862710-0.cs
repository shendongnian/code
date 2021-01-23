            DataTable dt = yourdatatable;
            DataTable dtable2 = new DataTable();
            dtable2.Columns.Add("column1", System.Type.GetType("System.String"));
            dtable2.Columns.Add("column2", System.Type.GetType("System.String"));
            dtable2.Columns.Add("column3", System.Type.GetType("System.String"));
            string value = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                value = dt.Rows[0][i].ToString();
                string[] splitPipeValue = value.Split('|');
                DataRow drow = dtable2.NewRow();
                drow[0] = splitPipeValue[0].ToString();
                drow[1] = splitPipeValue[1].ToString();
                drow[2] = splitPipeValue[2].ToString();
                dtable2.Rows.Add(drow);
            }
        }
