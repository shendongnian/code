    SqlConnection connect;
    connect = new SqlConnection(DAL.AccessLayerClass._connectionStr);
    connect.Open();
    SqlCommand command;
    command = new SqlCommand(@"backup database [" + System.Windows.Forms.Application.StartupPath + "\\Database\\AGMDB.mdf] to disk ='d:\svBackUp1.bak' with init,stats=10",connect);
    command.ExecuteNonQuery();
    connect.Close();
    MessageBox.Show("The support of the database was successfully performed", "Back", MessageBoxButtons.OK, MessageBoxIcon.Information);
