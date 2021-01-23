    private bool init;
     private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DropDownStyle =  ComboBoxStyle.DropDownList;
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(int));
        dt.Columns.Add("name", typeof(string));
        dt.Rows.Add(1, "A1");
        dt.Rows.Add(2, "A2");
        init = true;
        comboBox1.DataSource = dt;
        comboBox1.DisplayMember = "name";
        comboBox1.ValueMember = "id";   
        init = false;
    }
    private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
    {
        if(!init) MessageBox.Show("FOO");
    }
