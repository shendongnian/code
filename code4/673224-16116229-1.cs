    private void Form1_Shown(object sender, EventArgs e)
    {
        conexion.Open();       
        try
        {           
           MySqlDataAdapter da = new MySqlDataAdapter("select * from tbestados", conexion);
           DataSet ds = new DataSet();
           da.Fill(ds, "tbestados");
           comboBox1.ItemsSource = ds.Tables[0].DefaultView;
           comboBox1.DisplayMemberPath = ds.Tables[0].Columns["Nombre"].ToString();
           comboBox1.SelectedValuePath = ds.Tables[0].Columns["CveEstado"].ToString(); 
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    conexion.Close();
    }
