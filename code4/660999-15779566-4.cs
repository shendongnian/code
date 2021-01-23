     DataTable dt = new DataTable();
     string sql = "";
     for (int i = 0; i < dt2.Rows.Count; i++)
     {
        sql = sql + "insert into InvitationData (Col1, Col2, ColN) values('"
              + dt2.Rows[i]["columnname"].ToString().Trim() + "','"
              + dt2.Rows[i]["columnname"].ToString().Trim() + "','" 
              + dt2.Rows[i]["columnname"].ToString().Trim() + "')";
     }
