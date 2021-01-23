     public class TimeStamp
	    {
	        public Int32 UnixTimeStampUTC()
		    {
		        Int32 unixTimeStamp;
		        DateTime currentTime = DateTime.Now;
		        DateTime zuluTime = currentTime.ToUniversalTime();
		        DateTime unixEpoch = new DateTime(1970, 1, 1);
		        unixTimeStamp = (Int32)(zuluTime.Subtract(unixEpoch)).TotalSeconds;
		        return unixTimeStamp;
		    }
    }
