    using(OleDbConnection oleConn = GetConnection())
    {
        oleConn.Open();
        string vsql = "delete from login where Email=@mail";
        OleDbCommand vcom = new OleDbCommand(vsql, oleConn);
        vcom.Parameters.AddWithValue("@mail", deleterecordtextBox.Text);
        int recordsDeleted = vcom.ExecuteNonQuery();
        if(recordsDeleted != 0)
            MessageBox.Show("Record deleted successfully!!");
        else
            MessageBox.Show("Record not found!");
     }
     deleterecordtextBox.Clear();
     ......
