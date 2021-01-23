    var sb = new StringBuilder();
    sb.Append("select field1 ,field2, field3, fieldN ");
    sb.Append("from table t with(nolock) ");
    sb.Append("where ((@param1 is null) or (t.fieldX == @param1))");
    sb.Append("and ((@param2 is null) or (t.fieldX == @param2))");
    
    var connection = new SqlConnection("connection_string");
    var command = new SqlCommand();
    command.Connection = connection;
    command.CommandText = sb.ToString();
    command.CommandType = CommandType.Text;
    if((string.IsNullOrEmpty(stringVariable1) || (stringVariable2.ToLower().Equals("any"))) {
        command.Parameters.Add("@param1", SqlType.VarChar, 50).Value = DBNull.Value;
    } else {
        command.Parameters.Add("@param1", SqlType.VarChar, 50).Value = stringVariable1;
    }
    if((string.IsNullOrEmpty(stringVariable2) || (stringVariable2.ToLower().Equals("any"))) {
        command.Parameters.Add("@param2", SqlType.VarChar, 50).Value = DBNull.Value;
    } else {
        command.Parameters.Add("@param2", SqlType.VarChar, 50).Value = stringVariable2;
    }
