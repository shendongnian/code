        SqlParameter param1 = new SqlParameter();
        param1.ParameterName = "@name";
        param1.Value = nameTextBox.Text;
        param1.SqlDbType = SqlDbType.Text;
        param2 = new SqlParameter();
        param2.ParameterName = "@code";
        param2.Value = codeTextBox.Text;
        param2.SqlDbType = SqlDbType.Text;
        SQLconnect.Sql("INSERT INTO [dbo].[work] ([name],[code])VALUES(@name, @code)", param1, param2);
