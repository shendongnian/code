            System.Array arr = (System.Array)ws.get_Range(strRange, andRange).get_Value(Type.Missing);
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int cnt = 1;
                cnt <= col; cnt++)
                dt.Columns.Add(cnt.Chr(), typeof(string));
            for (int i = 1; i <= row; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 1; j <= col; j++)
                {
                    dr[j - 1] = arr.GetValue(i, j).ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
