    public class Test
    {
        public class Task
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            //... more 20 properties
        }
    
        public IQueryable<Task> Tasks;
    
        public Test()
        {
            Tasks = new List<Task>
                {
                    new Task {Id = 1, Name = "Task #1", Description = "Description task #1"},
                    new Task {Id = 2, Name = "Task #2", Description = "Description task #2"},
                    new Task {Id = 3, Name = "Task #3", Description = "Description task #3"}
                }.AsQueryable();
        }
    
        public IEnumerable<object> GetAllTasks(string[] fields)
        {
            var response = new List<object>();
            var customTasks = Tasks.SelectDynamic(fields).Cast<dynamic>();
            foreach (var t in customTasks.Take(100))
            {
                dynamic expando = new ExpandoObject();
    
                if (fields.Contains("Id")) expando.Id = t.Id;
                if (fields.Contains("Name")) expando.Name = t.Name;
                if (fields.Contains("Description")) expando.Description = t.Description;
                // ... other properties
    
                response.Add(expando);
            }
            return response;
        }
    }
