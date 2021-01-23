    try
    {
        con.Open();
        cmdselect.ExecuteNonQuery();
        object o = (int)cmdselect.Parameters["@OutRes"].Value;
        if (o == DBNull.Value)
            return 0;
        return (int)o;
    }
    catch (SqlException ex)
    {
        lblMessage.Text = ex.Message;
    }
    finally
    ....
