    private void btnSave_Click(object sender, EventArgs e)
    {
        //SqlConnection con = new SqlConnection(conn);
        OleDbConnection con = new OleDbConnection(conn);
        int i = 0;
        con.Open();
        //SqlCommand cmd;
        try
        {
            string query = "insert into GroupDetails (ID,Name) values(@ID,@Name)";
            // cmd = new SqlCommand(query,con);
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.Parameters.AddWithValue("@ID",txtID.Text);
            cmd.Parameters.AddWithValue("@Name",txtName.Text);
            i = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
        finally
        {
            con.Close();
            if(i!=0)
            {
                dataGridGroup.DataSource = GetData();
            }
        }
    }
