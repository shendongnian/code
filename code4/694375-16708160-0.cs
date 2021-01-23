      string query = "SELECT fam, name, patronymic, date_birth, adress, phone_number, salary, " + 
                     "position, brand, model, name_of_department FROM View2 " + 
                     "where position = @condition";
      string condition = string.Empty;
      switch(combobox1.SelectedIndex)
      {
           case 0:
              condition = "Директор";
              break;
           case 1:
              condition = "Коммерческий директор";
              break;
           ..... and so on 
    }
    if(!string.IsNullOrWhiteSpace(condition))
    {
        myCommand.CommandText = query;
        myCommand.Parameters.AddWithValue("@condition", condition);
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = myCommand;
        DataSet ds = new DataSet();
        dataAdapter.Fill(ds, "View2");
        dataGridView1.DataSource = ds.Tables["View2"].DefaultView;
    }
