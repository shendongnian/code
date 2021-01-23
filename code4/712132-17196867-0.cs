    private void Form1_Load(object sender, EventArgs e)
    {
        comboBox1.DropDownStyle =  ComboBoxStyle.DropDownList;
        DataTable dt = new DataTable();
        dt.Columns.Add("id", typeof(int));
        dt.Columns.Add("name", typeof(string));
        dt.Rows.Add(1, "A1");
        dt.Rows.Add(2, "A2");
        comboBox1.DataSource = dt;
        comboBox1.DisplayMember = "name";
        comboBox1.ValueMember = "id";
        comboBox1.SelectedValueChanged += comboBox1_SelectedValueChanged   
    }
