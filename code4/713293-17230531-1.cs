    void Main()
    {
    	var tracks = new[]
        {
            new Track{Id = 1, Device = "InReader", DateTime = new DateTime(2013,5,5,8,0,0), EmployeeId = 1},
    		new Track{Id = 2, Device = "InReader", DateTime = new DateTime(2013,5,5,8,0,5), EmployeeId = 1},
    		new Track{Id = 3, Device = "InReader", DateTime = new DateTime(2013,5,5,8,1,0), EmployeeId = 2},
    		new Track{Id = 4, Device = "InReader", DateTime = new DateTime(2013,5,5,8,2,0), EmployeeId = 3},
    		new Track{Id = 5, Device = "InReader", DateTime = new DateTime(2013,5,5,8,3,0), EmployeeId = 4},
    		
    		new Track{Id = 6, Device = "OutReader", DateTime = new DateTime(2013,5,5,17,0,0), EmployeeId = 1},
    		new Track{Id = 7, Device = "OutReader", DateTime = new DateTime(2013,5,5,17,5,5), EmployeeId = 2},
    		new Track{Id = 8, Device = "OutReader", DateTime = new DateTime(2013,5,5,17,5,10), EmployeeId = 2},
    		new Track{Id = 9, Device = "OutReader", DateTime = new DateTime(2013,5,5,17,10,0), EmployeeId = 3},
    		new Track{Id = 10, Device = "OutReader", DateTime = new DateTime(2013,5,5,17,30,0), EmployeeId = 4},
        };
    	
            // the Query
        	tracks
		.GroupBy(x => x.EmployeeId)
		.Select(x => new 
			{
				EmployeeId = x.Key,
				InTime = x.FirstOrDefault(y => y.Device.Equals("InReader")).DateTime,
				OutTime = x.LastOrDefault(y => y.Device.Equals("OutReader")).DateTime
			})
    }
    
    public class Track
    {
        public int Id { get; set; }
    
        public string Device { get; set; }
    
        public DateTime DateTime { get; set; }
    
        public int EmployeeId { get; set; }
    }
