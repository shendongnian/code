    using System;
    using System.Management;
    using System.Reflection;
    
    class ScheduleJob
    {
    	public static uint Create (
    string Command,
    uint DaysOfMonth,
    uint DaysOfWeek,
    bool InteractWithDesktop,
    bool RunRepeatedly,
    string StartTime, // in DMTF format !
    out uint JobId)
    	{
    // See: Platform SDK (or WMI SDK) doc's for detailed info about 'Win32_ScheduledJob' class
    		ManagementBaseObject inputArgs = null;
    		ManagementClass classObj = new ManagementClass (null, "Win32_ScheduledJob", null);
    		inputArgs = classObj.GetMethodParameters ("Create");
    		inputArgs ["Command"] = Command;
    		inputArgs ["DaysOfMonth"] = DaysOfMonth;
    		inputArgs ["DaysOfWeek"] = DaysOfWeek;
    		inputArgs ["InteractWithDesktop"] = InteractWithDesktop;
    		inputArgs ["RunRepeatedly"] = RunRepeatedly;
    		inputArgs ["StartTime"] = StartTime;
    // use late binding to invoke "Create" method on "Win32_ScheduledJob" WMI class
    		ManagementBaseObject outParams = classObj.InvokeMethod ("Create", inputArgs, null);
    		JobId = ((uint)(outParams.Properties ["JobId"].Value));
    		return ((uint)(outParams.Properties ["ReturnValue"].Value));
    	}
    // Delete the Scheduled (JobID)
    
    	public static uint Delete (uint JobID)
    	{
    		ManagementObject mo;
    		ManagementPath path = ManagementPath.DefaultPath;
    		path.RelativePath = "Win32_ScheduledJob.JobId=" + "\"" + JobID + "\"";
    		mo = new ManagementObject (path);
    		ManagementBaseObject inParams = null;
    // use late binding to invoke "Delete" method on "Win32_ScheduledJob" WMI class
    		ManagementBaseObject outParams = mo.InvokeMethod ("Delete", inParams, null);
    		return ((uint)(outParams.Properties ["ReturnValue"].Value));
    	}
    
    	public static string ToDMTFTime (DateTime dateParam)
    	{
    		string tempString = dateParam.ToString ("********HHmmss.ffffff");
    		TimeSpan tickOffset = TimeZone.CurrentTimeZone.GetUtcOffset (dateParam);
    		tempString += (tickOffset.Ticks >= 0) ? '+' : '-';
    		tempString += (Math.Abs (tickOffset.Ticks) / System.TimeSpan.TicksPerMinute).ToString ("d3");
    		return tempString;
    	}
    }
    
    class JobScheduler
    {
    	public static void Main ()
    	{
    		uint JobID;
    		DateTime dt = DateTime.Now; // Get current DateTime
    		dt = dt.AddMinutes (1); //add 1 minute to current time
    		string LocalDateTime = ScheduleJob.ToDMTFTime (dt); // convert to DMTF format
    // Schedule Notepad to run every Sunday and Wednesday
    		uint ret = ScheduleJob.Create (
    // @"runas /user:administrator\domain /profile cmd ",
    @"c:\winnt\notepad.exe",
    0, 32, true, true, LocalDateTime, out JobID);
    		if (ret == 0) { // sucess
    			Console.WriteLine ("Wait for Job to be scheduled and Press: <Enter> to delete");
    			Console.ReadLine (); // For test purposes - Wait for job to be scheduled.
    			ret = ScheduleJob.Delete (JobID); // Get rid of this Job
    		}
    		Console.WriteLine (ret);
    	}
    }
    
    /* Days of week
    Sunday 64,
    Monday 1,
    Tuesday 2,
    Wednesday 4,
    Thursday 8,
    Friday 16,
    Saturday 32
    
    */
