    SqlCommand myCommand = new SqlCommand(
       string.Format("Select * from Table where Name = @NameInput"), SqlConnection);
    
    SqlParameter param = new SqlParameter();
    param.ParameterName = "@NameInput";
    param.Value = textbox.Text;
    param.SqlDbType = SqlDbType.Char;
    myCommand.Parameters.Add(param);
