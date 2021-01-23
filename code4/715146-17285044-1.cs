    string cmdString = "SELECT ShortName FROM departments WHERE (ID = @depId)";
    using (SqlCommand SQl_Command2 = new SqlCommand(cmdString, SQl_Connection))
    {
        //a selected value in department_text would be the mailing code such as 1337, or 1304.
        SQl_Command2.Parameters.Add("@depId", System.Data.SqlDbType.Int).Value = department_Text.SelectedValue;
        string deptName = (string)SQl_Command2.ExecuteScalar();
    }
