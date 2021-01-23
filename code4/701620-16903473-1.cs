       private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Usuario\Documents\Visual Studio 2010\Projects\Nova\Nova\Database1.mdf;Integrated Security=True;User Instance=True"))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "insert into databaseTableName (Codigo,Nombre,Cantidad,Tipo) values (@Codigo, @Nombre, @Cantidad, @Tipo)";
                    cmd.Parameters.AddWithValue("@Codigo", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Nombre", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Cantidad", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Tipo", comboBox2.Text);
                    cmd.Connection = cn; //this was where the error originated in the first place.
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Acabas de agregar un producto");
                }
            }
        }
