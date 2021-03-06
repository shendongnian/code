    [WebMethod]
    public void downloadAttachment(string id)
    {
        string SQL =
              "select top 1 FILENAME, FILE_MIME_TYPE, ATTACHMENT" + ControlChars.CrLf
            + "  FROM vwATTACHMENTS_CONTENT" + ControlChars.CrLf
            + " where ID = @ATTACHMENT_ID" + ControlChars.CrLf
            + " order by DATE_ENTERED desc";
        //Debug.Print(SQL);
        DbProviderFactory dbf = DbProviderFactories.GetFactory();
        using (IDbConnection con = dbf.CreateConnection())
        using (IDbCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = SQL;
            Sql.AppendParameter(cmd, id, "ATTACHMENT_ID");
            using (DbDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    // Send the file to the browser
                    Response.AddHeader("Content-type", (string)r["FILE_MIME_TYPE"]);
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + (string)r["FILENAME"]);
                    Response.BinaryWrite((Byte[])r["ATTACHMENT"]);
                    Response.Flush();
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }
    }
