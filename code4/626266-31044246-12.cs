    public void MyParallelizedMethod()
    {
        // Shared variable. Not thread safe
        var itemCount = 0; 
    
        Parallel.For(myEnumerable, 
        // localInit - called once per Task.
        () => 
        {
           // Local `task` variables have no contention 
           // since each Task can never run by multiple threads concurrently
           var sqlConnection = new SqlConnection("connstring...");
           sqlConnection.Open();
           // This is the `task local` state we wish to carry for the duration of the task
           return new 
           { 
              Conn = sqlConnection,
              RunningTotal = 0
           }
        },
        // Task Body. Invoked once per item in the batch assigned to this task
        (item, loopState, taskLocals) =>
        {
          // ... Do some fancy Sql work here on our task's independent connection
          using(var command = taskLocals.Conn.CreateCommand())
          using(var reader = command.ExecuteReader(...))
          {
            if (reader.Read())
            {
               // No contention for `taskLocal`
               taskLocals.RunningTotal += Convert.ToInt32(reader["countOfItems"]);
            }
          }
          // The same type of our `taskLocal` param must be returned from the body
          return taskLocals;
        },
        // LocalFinally called once per Task after body completes
        // Also takes the taskLocal
        (taskLocals) =>
        {
           // Any cleanup work on our Task Locals (as you would do in a `finally` scope)
           if (Conn != null)
             Conn.Dispose();
    
           // Do any reduce / aggregate / synchronisation work.
           // NB : There is contention here!
           Interlocked.Add(ref itemCount, taskLocals.RunningTotal);
        }
 
