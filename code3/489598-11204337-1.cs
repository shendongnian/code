    public class CustomClass : IComparable<CustomClass>
    {
	public string Id { get; set; }        
	public string Name { get; set; }        
	public string EventName { get; set; }        
	public string EventDate { get
	{
		return EventDate;
	}
	set
	{
		if (value != null)
		{
			DateTime eventDate = DateTime.Parse(value);
			int today = DateTime.Now.Day;
			if (eventDate.Day <= today + 1 & eventDate.Day >= today - 2)
			{
				if (eventDate.Day == today)
				EventDate = "Today";
				else if (eventDate.Day == (today + 1))
				EventDate = "Tomorrow";
				else if (eventDate.Day == (today - 1))
				EventDate = "Yesterday";
				else if (eventDate.Day >= (today - 2))
				EventDate = "Just Passed";
			}
			else
			{
				EventDate = value;
			}
        }
	}
        private int Order { get {
           switch(EventDate) {
             case "Just Passed": return 1;
             case "Yesterday": return 2;
             case "Tomorrow": return 3;
             case "Today": return 4;
             default: return 5;
           }
        }
        }
        public int CompareTo(CustomClass other) {
           return this.Order.CompareTo(other.Order);
        }
    }
