    using (SqlCeConnection con = new SqlCeConnection(@"Data Source=G:\Dropbox\HND\Visual Studio\Visual C#\TestForms\TestForms\Database1.sdf"))
    {
        con.Open();
        string taskSel = "SELECT COUNT(*) FROM TaskCode";
        string cmdText; 
        SqlCeCommand c1 = new SqlCeCommand(taskSel, con);
        int count = (int)c1.ExecuteScalar();
        if (count > 0)
        {
            // Here there is no point to update the TaskCode. You already know the value
            // Unless you have a different value, but then you need another parameter
            // the 'old' TaskCode.....
            cmdText = "UPDATE TaskCode SET " + 
                      "TaskDescription = @TaskDescription " + 
                      "WHERE TaskCode = @TaskCode;";
        }
        else
        {
            cmdText = "INSERT INTO TaskCode VALUES (@TaskCode, @TaskDescription);";
        }
        try
        {
            SqlCeCommand c = new SqlCeCommand(cmdText, con);
            c.Parameters.AddWithValue("@TaskCode", cbx_taskCode.Text);
            c.Parameters.AddWithValue("@TaskDescription", txt_desc.Text);
            c.ExecuteNonQuery();
            MessageBox.Show(count > 0 ? "Record has been updated" : "Record has been added");
            MainMenu.Current.Show();
            this.Close();
        }
        catch (SqlCeException exp)
        {
             MessageBox.Show(exp.ToString());
        }
    }
