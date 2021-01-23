    private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
    {
        Object returnValue;
        using (OleDbCommand cmd = new OleDbCommand())
        {
            cmd.Connection = myCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT TOP 1 File FROM Table1 WHERE ID = @ID";
            cmd.Parameters.AddWithValue("@ID", txtID.Text);
            myCon.Open();
            returnValue = cmd.ExecuteScalar();
            myCon.Close();
        }
        if ((returnValue == null) || (returnValue == DBNull.Value))
        {
            // null was returned, meaning the ID wasn't found, or the "File" field has no value
            // handle the error appropriately...
        }
        else
        {
            // FilePath = @"C:\\myFolder\myFolder";
            String FilePath = returnValue.ToString();
            if (Directory.Exists(FilePath))
            {
                System.Diagnostics.Process.Start("Explorer.exe", @"/select," + FilePath);
            }
            else
            {
                // FilePath doesn't exist!
                // handle the error appropriately...
            }
        }
    }
