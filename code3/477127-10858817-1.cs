    void yourTextBox_TextChanged (object sender, EventArgs e)
    {
       SqlDataReader dReader;
       SqlConnection conn = new SqlConnection();
       conn.ConnectionString = strConnection;
       SqlCommand cmd = new SqlCommand();
       cmd.Connection = conn;
       cmd.CommandType = CommandType.Text; //better is to use a stored proc or if you use a .NET 3.5 or higher framework then LinqtoSQL
       cmd.CommandText = "Select [yourNameColumn] from yourNameTable where yourNameColumn LIKE" + yourTextBox.Text +"%"; //before lines from this you can set them initializing code part of your form..it will be your choice
       conn.Open();
       dReader = cmd.ExecuteReader();
       if (dReader.HasRows == true)
       {
           yourListOfTheMatchedNames.Clear(); // to clear previous search..its optional to depends of your choice
           while (dReader.Read())
           {                  
                  yourListOfTheMatchedNames.Add(dReader["Name"].ToString());    
           }
        }
        else
        {
            MessageBox.Show("There is No Customer Name Starts with You Typed");
        }
        dReader.Close();
    
        txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
        txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        txtName.AutoCompleteCustomSource = yourListOfTheMatchedNames;
                
    }
