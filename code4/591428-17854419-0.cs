    // ...
    sqlcmd.CommandText = "INSERT INTO MyTable(CompName, Num, Name) VALUES(@CompName, @Num, @Name)";
                        sqlcmd.Parameters.Add("@CompName", SqlDbType.VarChar).Value = CompName;
                        sqlcmd.Parameters.Add("@Num", SqlDbType.VarChar).Value = Num;
                        sqlcmd.Connection = sqlcon;                 
                        sqlcmd.ExecuteNonQuery();
                        DV_Test.ChangeMode(DetailsViewMode.Insert);
                        sqlcon.Close();
                        sqlcmd.Parameters.Clear();
    //...
