    if(!IsPostBack)
    {
        using (SqlConnection conn = new SqlConnection("myconnectionString"))
        {
            conn.Open();
            using (SqlCommand cmmnd = new SqlCommand("", conn))
            {
                cmmnd.CommandText = "SELECT * FROM addsetting;";
                SqlDataReader rdr = cmmnd.ExecuteReader();
                while (rdr.Read())
                {
                    count++;
                    param = Convert.ToString(rdr["rowno"]);
                    TextBox1.Text = Convert.ToString(rdr["tostudent"]);
                    TextBox2.Text = Convert.ToString(rdr["tofaculty"]);
                    TextBox3.Text = Convert.ToString(rdr["studentday"]);
                    TextBox4.Text = Convert.ToString(rdr["facultyday"]);
                    TextBox5.Text = Convert.ToString(rdr["firstweek"]);
                    TextBox6.Text = Convert.ToString(rdr["secondweek"]);
                    TextBox7.Text = Convert.ToString(rdr["thirdweek"]);
                }
                rdr.Close();
            }
            conn.Close();}
       
    }
