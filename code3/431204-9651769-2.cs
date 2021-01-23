    public void ReadData()
    {
      var taskList = new List<Task<SomeResultType>>();
    
      var command = new SqlCommand()
      {
        CommandText = "SELECT * FROM Table";
        Connection = new SqlConnection("InsertConnectionString");
      };
      using(var reader = command.ExecuteReader())
      {
        var valueList = new List<object[]>(100);
        while(reader.Read())
        {
          var values = new object[reader.FieldCount];
          reader.GetValues(values);
          
          valueList.Add(values);
          
          if(valueList.Count == 100)
          {
            var localValueList = valueList.ToList();
            valueList.Clear();
            
            taskList.Add(Task<SomeResultType>.Factory.StartNew(() => Process(localValueList));
          }
        }
        if(valueList.Count > 0)
          taskList.Add(Task<SomeResultType>.Factory.StartNew(() => Process(valueList));
      }
    
      // this line completes when all tasks are done
      Task.WaitAll(taskList.ToArray());
    }
    
    public SomeResultType Process(List<object[]> valueList)
    {
      foreach(var vals in valueList)
      {
        // put your processing code here, be sure to synchronize your actions properly
      }  
    }
