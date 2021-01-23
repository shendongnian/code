       public void Main()
        {
          string name = string.Empty;
          string[] variableCollection;
          variableCollection = Dts.Variables["User::Item"].Value.ToString().Split(',');
          using (SqlConnection conn = new SqlConnection(m_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("Insert into SSISVariables values (@name,@value)", conn);
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = variableCollection[0];
                command.Parameters.Add("@value", SqlDbType.VarChar).Value = variableCollection[1];
                command.ExecuteNonQuery();
            }
            // TODO: Add your code here
            Dts.TaskResult = (int)ScriptResults.Success;
        }
