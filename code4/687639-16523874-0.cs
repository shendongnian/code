    var jobs = new List<dynamic>
                   {
                     new
                     {
                       JobName = "Job1",
                       JobDate = "Date1",
                       JobUser = "User1"
                     },
                     new
                     {
                       JobName = "Job2",
                       JobDate = "Date2",
                       JobUser = "User2"
                     }
                   };
    			   
    jobs.Where(x=>x.JobName == "Job2").Dump();
