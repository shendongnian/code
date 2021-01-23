    String pkIndxNm = null;
    List<String> lstPkColNms = new List<String>();
    DataTable dt = dbConn.GetSchema("PrimaryKeys", new[] { owner, tblNm });
    if (dt.Rows.Count == 1) {
        DataRow pkRow = dt.Rows[0];
        pkIndxNm = pkRow["INDEX_NAME"] as String;
        // Now use the IndexColumns collection to pick up the names of the 
        // columns which constitute the primary key.
        //
        dt = dbConn.GetSchema("IndexColumns", new[] { owner, pkIndxNm });
        foreach (DataRow icRow in dt.Rows) {
            String colNm = icRow["COLUMN_NAME"] as String;
            lstPkColNms.Add(colNm);
        }
    }
