    using (SqlConnection cnn = new SqlConnection(connString))
    {
        cnn.Open();
        using (SqlDataAdapter sda = new SqlDataAdapater("SELECT e.DisplayName,  e.ID , e.GUID FROM ATable e INNER JOIN RootTable re ON e.ID = re.TablesID AND re.InitID = 1", cnn))
        {
            DataTable dt = new DataTable();
            sda.Fill(dt);
            comboBox.ValueMember = "ID";
            comboBox.DisplayMember = "DisplayName";
            comboBox.DataSource = dt;
        }
    }
