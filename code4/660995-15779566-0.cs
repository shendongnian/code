     DataTable dt = new DataTable();
            string sql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sql = sql + "insert into InvitationData (Col1, Col2, ColN) values(" + dt.Rows[i]["columnname"].ToString().Trim() + "," + dt.Rows[i]["columnname"].ToString().Trim() + "," + dt.Rows[i]["columnname"].ToString().Trim() + ")";
          
            }
