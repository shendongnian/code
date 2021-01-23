    while (sqldread.Read())
    {
         int Dbid = (int)sqldread["Id"];
    }
    sqldread.Close();
    Label4.Text = Convert.ToString(Dbid);
    String QueryStr = "INSERT INTO User_Images(Id,Image) VALUES ('" + Dbid + "',@Image)";
    SqlCommand scmd1 = new SqlCommand(QueryStr, conn);
    scmd1.Parameters.Add("@Image", SqlDbType.VarBinary).Value = imgbytes;
    SqlDataReader sqldread = scmd1.ExecuteNonQuery();
