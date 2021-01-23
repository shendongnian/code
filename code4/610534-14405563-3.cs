        private void cmdAdd_Click(object sender, EventArgs e)
        {
            string strSQL = "INSERT INTO TestTable(Name1, Address) VALUES(@FirstName, @Address)";
            OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\TEMP\\TestDatabase.accdb");
            OleDbCommand myCommand = new OleDbCommand(strSQL, myConnection);
            myCommand.Parameters.Add("@FirstName", OleDbType.VarChar).Value = txtName.Text;
            myCommand.Parameters.Add("@Address", OleDbType.VarChar).Value = txtAddress.Text;
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
            finally
            {
                myConnection.Close();
            }
        }
