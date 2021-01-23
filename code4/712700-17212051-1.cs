    try
    {
        DbConnection1.Open();
        OdbcCommand DbCommand1 = DbConnection1.CreateCommand();
        DbCommand1.CommandText = "INSERT INTO tblhelp (grid) VALUES (?)";
        OdbcParameter param1 = new OdbcParameter("param1", OdbcType.VarChar);
        param1.Value = TextBox7.Text;
        DbCommand1.Parameters.Add(param1);
        Int32 t1 = DbCommand1.ExecuteNonQuery();
        if (t1 == 1)
        {
            DbConnection1.Close();
        }
        else
        {
        }
    }
    catch (Exception ex)
    {
        //do something!
    }
