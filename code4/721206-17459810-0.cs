     List<string> dataList = new List<string>(); // this line is global not inside a closed scoop
     var myDataTable = new System.Data.DataTable();
     using (var conection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" + "data source="+foldername+"\\Program\\Ramdata.mdb;Jet OLEDB:Database Password=****"))
     {
        conection.Open();
        var query = "Select u_company From t_user";
        var command = new System.Data.OleDb.OleDbCommand(query, conection);
        var reader = command.ExecuteReader();                    
        while (reader.Read())
        {
           profselect.Text = reader[0].ToString(); 
           dataList.Add(profselect.Text);
        }
     }
     myComboBox.DataSource = dataList;
     myComboBox.SelectedText = dataList.Last();
    
