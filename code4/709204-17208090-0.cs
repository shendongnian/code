    using System;
    using System.Runtime.InteropServices;
    namespace changeHour
    {	
	public class cDateTime	
	{		
				
		[StructLayout(LayoutKind.Sequential)]		
		private struct SystemTime
		{			
			public ushort uYear;			
			public ushort uMonth;			
			public ushort uDayOfWeek;			
			public ushort uDay;			
			public ushort uHour;			
			public ushort uMinute;			
			public ushort uSecond;			
			public ushort uMilliseconds;			
			public SystemTime(
				ushort uYear, 
				ushort uMonth, 
				ushort uDay, 
				ushort uHour, 
				ushort uMinute, 
				ushort uSecond)
			{				
				this.uYear = uYear;				
				this.uMonth = uMonth;				
				this.uDayOfWeek = 0;				
				this.uDay = uDay;				
				this.uHour = uHour;				
				this.uMinute = uMinute;				
				this.uSecond = uSecond;				
				this.uMilliseconds = 0;			
			}		
		}		
		[DllImport("Coredll.dll")]			
		private static extern bool SetLocalTime(ref SystemTime st);
               [DllImport("Coredll.dll")]			
               private static extern uint SetSystemTime(ref SystemTime st);		
	
	
  
		public static bool SetDateTime(
			int iYear, 
			int iMonth, 
			int iDay, 
			int iHour, 
			int iMinute, 
			int iSecond)		
		       {			
			SystemTime st = 
				new SystemTime
				(
				Convert.ToUInt16(iYear), 
				Convert.ToUInt16(iMonth), 
				Convert.ToUInt16(iDay), 
				Convert.ToUInt16(iHour), 
				Convert.ToUInt16(iMinute), 
				Convert.ToUInt16(iSecond)
				);			
			return SetLocalTime(ref st);		
		}
        public static uint SetDateTimeSystem(
            int iYear,
            int iMonth,
            int iDay,
            int iHour,
            int iMinute,
            int iSecond)
        {
            SystemTime st =
                new SystemTime
                (
                Convert.ToUInt16(iYear),
                Convert.ToUInt16(iMonth),
                Convert.ToUInt16(iDay),
                Convert.ToUInt16(iHour),
                Convert.ToUInt16(iMinute),
                Convert.ToUInt16(iSecond)
                );
            return SetSystemTime(ref st);
        }		
		
		public static bool SetDateTime(DateTime dt)		
		{			
			return SetDateTime
				(
				dt.Year, 
				dt.Month, 
				dt.Day, 
				dt.Hour, 
				dt.Minute, 
				dt.Second
				);		
		}		
		
		public static bool SetDate(int iYear, int iMonth, int iDay)
		{			
			DateTime dt = DateTime.Now;			
			return SetDateTime(
				iYear, 
				iMonth, 
				iDay, 
				dt.Hour, 
				dt.Minute, 
				dt.Second);		
		}		
		public static bool SetDate(DateTime date)		
		{			DateTime time = DateTime.Now;			
			return SetDateTime(
				date.Year, 
				date.Month, 
				date.Day, 
				time.Hour, 
				time.Minute, 
				time.Second);		
		}		
		public static bool SetTime(int iHour, int iMinute, int iSecond)
		{			
			DateTime dt = DateTime.Now;			
			return SetDateTime(
				dt.Year, 
				dt.Month, 
				dt.Day, 
				iHour, 
				iMinute, 
				iSecond);		
		}		
		
 
		public static bool SetTime(DateTime time)		
		{			
			DateTime date = DateTime.Now;			
			return SetDateTime(
				date.Year, 
				date.Month, 
				date.Day, 
				time.Hour, 
				time.Minute, 
				time.Second);		
		}		
		
	}
     }
