    foreach (Control c in this.Controls)
    {
        ComboBox comboBox = c as ComboBox;
        if (comboBox != null)
        {        
            comboBox.DataSource = new DataView(DataSet1.Tables[0]);
            comboBox.DisplayMember = "Articles";
        }
    }
