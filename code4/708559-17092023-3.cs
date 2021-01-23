    public static List<Activity.StatusEnum> StatusList()
    {
    	var statusesToShow = Activity.StatusEnum.Open | Activity.StatusEnum.Rejected | Activity.StatusEnum.Accepted | Activity.StatusEnum.Started;
    	
    	return Enum
    		.GetValues(typeof(Activity.StatusEnum))
    		.Cast<Activity.StatusEnum>()
    		.Where(x => (x & statusesToShow) == x)
    		.ToList();
    }
