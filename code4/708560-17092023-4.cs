    public static List<Activity.StatusEnum> StatusList()
    {
    	return new List<Activity.StatusEnum> {
    		Activity.StatusEnum.Open, 
    		Activity.StatusEnum.Rejected, 
    		Activity.StatusEnum.Accepted, 
    		Activity.StatusEnum.Started
    	};
    }
