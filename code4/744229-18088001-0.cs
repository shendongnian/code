        using (SqlConnection con = new SqlConnection("Server=.;Integrated Security=true;Initial catalog=School"))
            {
                con.Open();
                SqlCommand cmd=new SqlCommand("select * from tbl_student",con);
                DataTable dt=new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
            }
