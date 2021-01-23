    //set up SqlCommand
    SqlCommand UpdateCmd = new SqlCommand();
    UpdateCmd.Connection = conn;
    //build your dictionary (probably happens elsewhere in your code)
    Dictionary<string, object> parameters = new Dictionary<string, object>();
    parameters.Add("col1", "col1 value");
    parameters.Add("col2", 42);
    parameters.Add("col3", DateTime.Now);
    //build a command string and add parameter values to your SqlCommand
    StringBuilder builder = new StringBuilder("UPDATE sometable SET ");
    foreach(KeyValuePair<string, object> parameter in parameters) {
        builder.Append(parameter.Key).Append(" = @").Append(parameter.Key).Append(",");
        UpdateCmd.Parameters.AddWithValue("@" + parameter.Key, parameter.Value);
    }
    builder.Remove(builder.Length - 1,1);
    //set the command text and execute the command
    UpdateCmd.CommandText = builder.ToString();
    UpdateCmd.ExecuteNonQuery();
