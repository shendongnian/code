    using(SqlConnection sqcon = new SqlConnection(
    "Data Source=WMLON-Z8-SQL20,61433;Initial Catalog=statusdb;Integrated Security=True"))
    {
        sqcon.Open();
        using(SqlCommand command = new SqlCommand(squery,sqcon)){
            command.CommandType = CommandType.Text;
            using(SqlDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    Console.WriteLine(reader[0]+"\t"+reader[1]);
                }
            }
    } 
