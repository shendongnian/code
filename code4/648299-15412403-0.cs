    SqlCeConnection conn = new SqlCeConnection(@"Data Source=|datadirectory|databse.sdf");
                conn.Open();
                SqlCeDataAdapter da = new SqlCeDataAdapter("select MyDesiredValue from StudentDetails where StudentID = " + studentIDTextBox.Text + "", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                label1.Text = dt.Rows[0][0].ToString();
