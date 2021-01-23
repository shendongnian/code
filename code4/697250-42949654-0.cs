                SqlConnection conn=New   SqlConnection("SERVER=127.0.0.1;DATABASE=bdss;UID=sa;PASSWORD=1234");
                SqlDataAdapter adpt = new SqlDataAdapter("select * from products",conn);
                DataTable dt = new System.Data.DataTable();
                adpt.Fill(dt);
                int count = dt.Rows.Count;
    
                dataGridView1.DataSource = dt;
