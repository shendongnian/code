            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(oldDt.Columns["StationID"]);
            for (int i = 0; i < oldDt.Rows.Count; i++)
            {
                dt.Rows[i]["StationID"] = oldDt.Rows[i]["StationID"];
            }
            ds.Tables.Add(dt);
