	void Main()
	{
		var list = new List<SubmissionLog>
		{
			new SubmissionLog(1, 123, "1/24/2013 01:00:00", 1),
			new SubmissionLog(2, 456, "1/24/2013 01:30:00", 1),
			new SubmissionLog(3, 123, "1/25/2013 21:00:00", 2),
			new SubmissionLog(4, 456, "1/25/2013 21:30:00", 2),
			new SubmissionLog(5, 123, "2/25/2013 22:00:00", 1),
			new SubmissionLog(6, 123, "2/26/2013 21:00:00", 2),
			new SubmissionLog(7, 123, "2/16/2013 21:30:00", 1),
		};
		
		// split out status 1 and 2
		var s1s = list.Where (l => l.StatusId == 1).OrderBy (l => l.Created);
		var s2s = list.Where (l => l.StatusId == 2).OrderBy (l => l.Created);
		
		// use a sub-query to get the first s2 after each s1
		var q = s1s.Select (s1 => new 
			{
				s1, 
				s2 = s2s.FirstOrDefault (s2 => 
					s1.SubmissionId == s2.SubmissionId &&
					s2.Created >= s1.Created	
				)
			}
		).Where (s => s.s1.PKId < s.s2.PKId && s.s2 != null);
	
			// extract the info we need	
			// note that TotalSecond is ok in Linq to Object but you'll 
			// probably need to use SqlFunctions or equivalent if this is to 
			// run against a DB.
		var q1 = q.Select (x => new 
			{
				Start=x.s1.Created,
				End=x.s2.Created,
				SubmissionId=x.s1.SubmissionId, 
				Seconds=(x.s2.Created - x.s1.Created).TotalSeconds
			}
		);
		
			// group by submissionId and average the time
		var q2 = q1.GroupBy (x => x.SubmissionId).Select (x => new {
			x.Key, 
			Count=x.Count (),
			Start=x.Min (y => y.Start),
			End=x.Max (y => y.End),
			Average=x.Average (y => y.Seconds)});
	}
    public class SubmissionLog
    {  
    	public SubmissionLog(int id, int submissionId, string date, int statusId)
    	{
    		PKId = id;
    		SubmissionId = submissionId;
    		Created = DateTime.Parse(date, CultureInfo.CreateSpecificCulture("en-US"));
    		StatusId = statusId;
    	}
        public int PKId {get;set;}  
        public int SubmissionId {get;set;}  
        public DateTime Created {get;set;}   
        public int StatusId {get;set;}
    }
