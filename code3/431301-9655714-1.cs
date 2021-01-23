     // My MODIFIED CODE WOULD BE
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(@"Data Source=PRATHAP-GENNY\SQLEXPRESS;Initial Catalog=Testing;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select productname, barcodetest from Testtable where barcodetest=@barcodetest", conn);
            cmd.Parameters.AddWithValue("@barcodetest", barcode.Text);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            { 
                textBox1.Visible= true;
                textBox1.Text = Convert.ToString(reader["productname"]);
                textBox2.Visible = true;
                textBox2.Text = Convert.ToString(reader["barcodetest"]);
            }
            else
            {
                textBox1.Visible = textBox2.Visible= false;
            }
