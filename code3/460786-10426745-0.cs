    sqlCon = new SqlConnection(@"Data Source=PC-PC\PC;Initial Catalog=Anbar;Integrated Security=True");
      SqlDataAdapter da = new SqlDataAdapter("Select StudentName from School", sqlCon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            yourComboBox.DataSource = dt;
            yourComboBox.DisplayMember = "StudentName";
            yourComboBox.ValueMember = "StudentName";
