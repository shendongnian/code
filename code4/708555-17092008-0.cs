    void Main()
    {
    	Activity.StatusList().Dump();
    	Enum.GetValues(typeof(Activity.StatusEnum)).Cast<Activity.StatusEnum>().OrderBy(se =>(int)se).Take(4).Dump();
    }
    
    // Define other methods and classes here
    public static class Activity {
    public enum StatusEnum
    {
        Open = 1,
        Rejected = 10, // changed to 10 for testing
        Accepted = 3,
        Started = 4,
        Completed = 5,
        Cancelled = 6,
        Assigned = 7,
    }
    
    public static List<StatusEnum> StatusList()
    {
            IEnumerable<Activity.StatusEnum> query = Enum.GetValues(typeof(Activity.StatusEnum)).Cast<Activity.StatusEnum>()
                            .Where(x => x == Activity.StatusEnum.Open
                                || x == Activity.StatusEnum.Rejected
                                || x == Activity.StatusEnum.Accepted
                                || x == Activity.StatusEnum.Started);
            return query.ToList();
    }
