    DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    TimeSpan span = DateTime.UtcNow - Jan1st1970;
    
    unchecked{
		 int mm = Int32.MaxValue;
		 mm += (int)(span.TotalMilliseconds % Int32.MaxValue);
		 Console.WriteLine(mm);	
    }
