    OleDbConnection con = new OleDbConnection();
    con.ConnectionString = "provider = microsoft.ace.oledb.12.0;data source = E:\\Sohkidatabase\\Sohki.accdb";
    OleDbCommand cmd = new OleDbCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = @"INSERT INTO Challan_No(challan,goods,quantity,nwlm,rate,total,ident,taaff,dateissue,nature,factory,expected,palce,date)VALUES
                    (" + labelchallan.Text + ",'" + textGood.Text + "'," + combQuit.Text + "," + combNwlm.Text + "," + textRate.Text + "," + textvalu.Text + ",'" + textIdent.Text + "','" + texttfclass.Text + "','" + dateTimeIssue.Text + "','" + textNatup.Text + "','" + textFact.Text + "','" + textExpDu.Text + "','" + textPlace.Text + "','" + dateTimeDate.Text + "')";
    cmd.Connection = con;
    con.Open();
    cmd.ExecuteNonQuery();
    System.Windows.Forms.MessageBox.Show("Recrod Succefully Created");
    con.Close();
