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
