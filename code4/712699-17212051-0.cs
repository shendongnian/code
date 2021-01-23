    try
    {
        DbConnection1.Open();
        OdbcCommand DbCommand1 = DbConnection1.CreateCommand();
        //DbCommand1.CommandText = "UPDATE TBL_ITHELPDESK SET STATUS='"+ chkClosed.Text +"',CLOSED_BY='"+drpClosedBy.Text+"',CLOSED_ON=TO_DATE('"+txtClosedOn.Text.ToString().Trim()+"','MM-DD-YYYY')WHERE CALL_NO='" + txtCallNo.Text + "'";
        DbCommand1.CommandText = "insert into tblhelp(grid) values(@Data0)";
        DbCommand1.Parameters.Add("@Data", OdbcType.VarChar, TextBox7.Text.Length);
        DbCommand1.Parameters["@Data"].Value = TextBox7.Text;
        TextBox7.Text=DbCommand1.CommandText.ToString();
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
