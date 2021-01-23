    public void ExecuteCommandSafely(Action<SqlCommand> callback) {
       ... do init stuff ...
       using (var connection = new SqlConnection(...)) {
          using (var command = new SqlCommand() {
             command.Connection = connection;
             try{
                callback(command);
             }
             ... error handling stuff ...
          }          
       }
    }
