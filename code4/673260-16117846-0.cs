    private void Form1_Shown(object sender, EventArgs e)
    {
        conexion.Open();
        textBox2.Focus();
        try
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT cveestado, nombre FROM tbestados", conexion);
            da.Fill(dt);
            //Here Comes your DataGridView
            DataGridView1.DataSource = dt;
            conexion.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
