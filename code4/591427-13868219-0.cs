    sqlcmd.CommandText = "INSERT INTO MyTable(CompName, Num, Name) VALUES(@CompName, @Num, @Name)";
    sqlcmd.Parameters.Add("@CompName", SqlDbType.VarChar);
    sqlcmd.Parameters.Add("@Num", SqlDbType.VarChar);
    foreach (ListItem listItem in cblCustomerList.Items)
    {
        if (....)
        {
            ....
        }
        else
        {
            dr.Close();
            sqlcmd.Parameters["@CompName"].Value = CompName;
            sqlcmd.Parameters["@Num"].Value = Num;
            sqlcmd.Connection = sqlcon;                 
            sqlcmd.ExecuteNonQuery();
            DV_Test.ChangeMode(DetailsViewMode.Insert);
            sqlcon.Close();
        }
    }
