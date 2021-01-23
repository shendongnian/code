    public struct DateInterval
    	{
    		public DateTime StartDate { get; set; }
    		
    		public DateTime EndDate { get; set; }
    
    		public bool HasIntersection(DateInterval secondInterval)
    		{
    			return HasIntersection(this.StartDate, this.EndDate,secondInterval.StartDate,secondInterval.EndDate);
    		}
    		private bool HasIntersection(DateTime dateStart1, DateTime dateEnd1, DateTime dateStart2, DateTime dateEnd2)
    		{
    			if (dateEnd1 < dateStart2) return false; 
    			if (dateEnd2 < dateStart1) return false; 
    			return true;
    		}
    	}
