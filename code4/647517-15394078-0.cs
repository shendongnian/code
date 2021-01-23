    public void LoadCb()
    {
        SqlConnection cn = new SqlConnection("connectionstring");
        SqlDataAdapter da = new SqlDataAdapter("select DealerId, DealterName from Dealers", cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        comboBox1.DataSource = dt;
        comboBox1.DisplayMember = "DealerName";
        comboBox1.ValueMember = "DealerId";
    }
