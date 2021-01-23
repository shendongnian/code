    con1.ConnectionString =   ConfigurationManager.ConnectionStrings["KedarnathDB"].ConnectionString;
  
    con1.Open();
    
    OleDbCommand cmd = new OleDbCommand("DELETE from ReceiptsTrns Where ID=@RCName", con1);
    cmd.Parameters.Add("@RCName", OleDbType.Numeric).Value = txtRcptNo.Text.Trim();
    **cmd.ExecuteNoQuery();**
    con1.Close();
