    using (MySqlCommand cmd = new MySqlCommand(commandLine, connect))
    {
            connect.Open();
            var obj = cmd.ExecuteScalar();
            int count = 0;
            if (obj != null)
            {
               count = Convert.toInt32(obj);
            }
            return count;
    }
