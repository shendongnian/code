       private void btn_login_Click(object sender, EventArgs e)
        {
             MySqlConnection con = new MySqlConnection("server=localhost;uid=root;password=abc;database=mydb");
             MySqlCommand cmd = new MySqlCommand("select * from emp where name='" + textBox1.Text + "'and pwd='" + textBox2.Text + "'",con);
             con.Open();
             MySqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.Read()) 
            {    //successful
                //navigate to next page or whatever you want
            }
            else
                Label1.Text("Invalid userid or password");
            con.Close();
        }
