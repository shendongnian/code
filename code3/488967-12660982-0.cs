        // get connection strings from app.config
        string conString = ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString;
        // connection object
        SqlCeConnection myConn = new SqlCeConnection(conString);
        // create adapter
        SqlCeDataAdapter myAdapter = new SqlCeDataAdapter("select * from [Sent]", myConn);
        // create command builder
        SqlCeCommandBuilder myCommandBuilder = new SqlCeCommandBuilder(myAdapter);
        // create dataset
        DataSet myDataSet = new DataSet();
        // fill dataset into named table
        myAdapter.Fill(myDataSet, "Sent");
        // create new row
        DataRow newRow = myDataSet.Tables["Sent"].NewRow();
        // set field vals
        newRow["sendTo"] = sendTo;
        newRow["subject"] = subject;
        newRow["message"] = message;
        // add new row to table
        myDataSet.Tables["Sent"].Rows.Add(newRow);
        // update database
        myAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();
        int updatedRows = myAdapter.Update(myDataSet, "Sent");
        //MessageBox.Show("There were "+updatedRows.ToString()+" updated rows");
        // close connection
        myConn.Close();
