      public class StatusDTO
        {
            public int StatusId { get; set; }
            public string Name { get; set; }
            public DateTime Created { get; set; }
        }
    
        public class statusJasonModel
        {
            public StatusDTO status { get; set; }
        }
