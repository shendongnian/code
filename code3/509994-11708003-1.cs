    public void Insertaddress()
    {
        String KKStech = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=KKSTech;Integrated Security=True";
        SqlConnection conn = new SqlConnection(KKStech);
        String str = @"insert into Contact (Addressline1, Addressline2, CityID, EmpID)
                                    values(@Addressline1, @Addressline2, @CityID, @EmpID)";
        SqlCommand cmd = new SqlCommand(str, conn);
        cmd.CommandText = str;
        cmd.CommandType = CommandType.Text;
        try
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@Addressline1", TextBox15.Text);
            cmd.Parameters.AddWithValue("@Addressline2", TextBox17.Text);
            cmd.Parameters.AddWithValue("@CityID", DropDownList2.SelectedValue);
            cmd.Parameters.AddWithValue("@EmpID", TextBox1.Text);
            cmd.ExecuteNonQuery();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
            throw new Exception(msg);
        }
        finally
        {
            conn.Close();
        }
    }
