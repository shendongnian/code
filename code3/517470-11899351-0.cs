    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Test;Integrated Security=True");
                SqlDataAdapter da = new SqlDataAdapter("select * from Books",con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "ID";
                comboBox1.DataSource = dt;
