    byte[] imageDatas = ReadFile(strFn);
    try
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        OdbcCommand cmd = new OdbcCommand("insert into students(id,name,img) values(" + txtId.Text + ",'" + txtName.Text + "',?)", con);
        cmd.Parameters.AddWithValue("@img", imageDatas);
        cmd.ExecuteNonQuery();
        MessageBox.Show("inserted successfully");
        con.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
