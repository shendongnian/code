            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(@"Data Source=PRATHAP-GENNY\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select barcodetest from Testtable where barcodetest=@barcodetest", conn);
            cmd.Parameters.AddWithValue("@barcodetest", barcode.Text);
            reader = cmd.ExecuteReader();
            if (reader != null && reader.HasRows)
            {
                //email exists in db do something
                TextBox2.Visible = true;
            }
            else
            {
                TextBox3.Visible = true;
            }
            
           
