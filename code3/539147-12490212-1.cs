    public class ActivityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Thumbnail { get; set; }
        public virtual Image Image { get; set; }
    }
    public IEnumerable<Activity> All()
    {
        return db.Activities.Select(a => new ActivityDto(){
    		Name = a.Name,
    		Description = a.Description,
    		Thumbnail = a.Thumbnail
    		// More properties if you need
    	}).ToArray();
    }
