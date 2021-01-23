    void autogen()
    {
        cmd = new SqlCommand("select count(*) from Employee", con);
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            i = int.Parse(dr[0].ToString()) + 1;
        }
        dr.Close();
        cmd.Dispose();
        if (i <= 9)
        {
            TextBox1.Text = "EID0" + i.ToString();
        }
        else if (i <= 99)
        {
            TextBox1.Text = "EID" + i.ToString();
        }
    }
