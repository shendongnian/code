    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
    }
    
    var tasks = new List<Task>(); // create a list to populate with tasks
    
    using (var connection = new SQLiteConnection(connString))    
    {
        var command = new SQLiteCommand(sql, conn);
        command.Parameters.Add("@userId", userId); // only do .ToString on userId if the column is a string.
    
        connection.Open();
        using (var reader = cmd.ExecuteReader()) 
        {
            while (reader.Read()) 
            {
                var task = new Task();
                task.Id = reader["id"]; // the name of the column in the reader will match the column in the Tasks table.
                task.Name = reader["name"];
                task.Key = reader["key"];
    
                tasks.Add(task);
            }
        }
    }
    
    return tasks;
