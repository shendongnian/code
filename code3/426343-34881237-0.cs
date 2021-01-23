    ComboBox1.SelectedIndexChanged -= new System.EventHandler(ComboBox1_SelectedIndexChanged); 
    ComboBox1.DataSource = dataTable; 
    ComboBox1.ValueMember = "id";  
    ComboBox1.DisplayMember = "name";
    ComboBox1.SelectedIndexChanged += new System.EventHandler(ComboBox1_SelectedIndexChanged);
