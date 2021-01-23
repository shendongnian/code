    String st = "UPDATE supplier SET supplier_id = " + textBox1.Text + ", supplier_name = " + textBox2.Text
                + "WHERE supplier_id = " + textBox1.Text;
            SqlCommand sqlcom = new SqlCommand(st, myConnection);
            try
            {
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("update successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
