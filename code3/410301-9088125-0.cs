        void Main()
        {
             var stringDates = new List<string> { "2011-13-01", "2011-01-12" };
    	
             DateTime paramDate = new DateTime(2011,01,13);
    	
    	     var q = from stringDate in stringDates
    	        let realdate = stringDate.SafeParse()
    	        where realdate == paramDate
    	        select new { stringDate, realdate };
    	
    	     q.Dump();
        }
    
    
        static class StringDateParseExt
        {
           public static DateTime SafeParse(this string  any)
        	{
        	  DateTime parsedDate;
        	  DateTime.TryParseExact(any, 
        	  		"yyyy-dd-MM", 
        			System.Globalization.CultureInfo.InvariantCulture , 
        			System.Globalization.DateTimeStyles.None, 
        			out parsedDate);
        	  return parsedDate;
        	}
        }
