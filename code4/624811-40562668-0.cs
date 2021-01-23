         SqlCommand cmd6 = new SqlCommand("SELECT * FROM tblinv WHERE invno='" + textBox5.Text + "'",cn);
            SqlDataReader sqlReader6 = cmd6.ExecuteReader();
            if (sqlReader6.HasRows)
            {
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt.Load(sqlReader6);
                dt1 = dt.DefaultView.ToTable(true, "ChallanNo", "ProductName", "UoM", "Price", "Qty","Subtotal");
                dataGridView2.DataSource = dt1;
            }
