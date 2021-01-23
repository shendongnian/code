     [DataContract]
            public class TaskClass
            {
                [DataMember(Name="task")]
                public string task { get; set; }
        
                [DataMember(Name="quantity")]
                public string quantity { get; set; }
        
                [DataMember(Name="state")]
                public string state { get; set; }
        
                [DataMember(Name = "changed")]
                public string changed { get; set; }
            }
        
            [DataContract]
            public class Tasks
            {
                [DataMember(Name = "tasks")]
                public IEnumerable<TaskClass> tasks { get; set; }
            }
    
    //and you can deserialize json :
    
        string json = "{\"tasks\":[{\"task\": \"Task1\",\"quantity\": \"(1)\",\"state\": \"incomplete\",\"changed\": \"never\"},{\"task\": \"Task2\",\"quantity\": \"(1)\",\"state\": \"complete\",\"changed\": \"never\"},{\"task\":\"Task3\",\"quantity\": \"(1)\",\"state\": \"deleted\",\"changed\": \"never\" }]}";
        
                Tasks allTasks = new Tasks();
                allTasks = JsonConvert.DeserializeObject<Tasks>(json);
    
                foreach (TaskClass task in allTasks.tasks)
                {
                    if (task.task.ToLower() == "task2")
                    {
                        task.state = "deleted";
                    }
                }
    
    //and serialize it again as :
    
    string value = JsonConvert.SerializeObject(objTasks);
