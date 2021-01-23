    private void button4_Click(object sender, EventArgs e)
    {
        try
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = db.todosUsuario("select usuario from usuarios");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Exception");
        }
    }
    //DB class
    public DataSet todosUsuario(string query)
    {
        DataSet dt = new DataSet();
        using (MySqlConnection cnn = new MySqlConnection(MysqlConnect()))
        {
            cnn.Open();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, cnn))
            {
                da.Fill(dt, "Usuario");
            }
            cnn.Close();
        }
        return dt;
    }
