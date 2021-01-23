    protected void Submit_Click(object sender, EventArgs e)
    {
        string strCon = "Server=yourServer;Database=yourDB;User Id=Username;Password=Password;";
        SqlConnection sqlConn = new SqlConnection(strCon);
        SqlCommand cmd = new SqlCommand("select * from Console where Text = @TextTmp", sqlConn);
        cmd.Parameters.AddWithValue("@TextTmp", txtString.Text);
    
        try
        {
            sqlConn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                txtString.Text = reader["Text"].ToString();
                lblMessage.Text = txtString.Text + "String is already exists";
            }
            else
            {
                lblMessage.Text = txtString.Text + "No data";
                 txtString.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
