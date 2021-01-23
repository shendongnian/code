    using(SqlConnection sqcon = new SqlConnection(
    "Data Source=WMLON-Z8-SQL20,61433;Initial Catalog=statusdb;Integrated Security=True"))
    {
       using(SqlCommand command = new SqlCommand(squery,sqcon)){
          command.CommandType = CommandType.Text;
          sqcon.Open();
          using(SqlDataReader reader = command.ExecuteReader())
          {
              while(reader.Read()){
                Console.WriteLine(reader[0]+"\t"+reader[1]);
              }
          }
          sqcon.Close();
       }
    } 
    -- Using EXISTS or IN could improve your query
        SELECT DISTINCT
                Context.ContextId ,
                ContextName
        FROM    Context
                INNER JOIN RunInstance ON Context.ContextId = RunInstance.ContextId 
                INNER JOIN ProcessInstance ON RunInstance.RunInstanceId = ProcessInstance.RunInstanceId
        WHERE	RiskDate = '2010-08-20'
