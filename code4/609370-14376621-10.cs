    public List<Metrics> MetricsParser(DateTime StartDate, TimeSpan StartTime, DateTime EndDate, TimeSpan EndTime,int dateIndex,int timeIndex)
    {
        DateTime sd = StartDate;
        DateTime ed = EndDate;
        TimeSpan st = StartTime;
        TimeSpan et = EndTime;
        List<Metrics> parsedFileData = new List<Metrics>();
		using (StreamReader streamReader = new StreamReader("file.csv"))
        {
            while (!streamReader.EndOfStream)
			{
				var line = streamReader.ReadLine();
			
				if(IsLineNeedToBeParsed(line))
					parsedFileData.Add(ParseLine(line));
			} 
        }
		
        return parsedFileData;
    }
	
	private bool IsLineNeedToBeParsed(string line)
	{
		return !(line.StartsWith("#")) && (line.Length > 0) && IsInDateRange(line);
	}
	
	private bool IsInDateRange(string line)
	{
		var dateVal = GetDateTime(line);
		return dateVal >= new DateTime(sd.Year, sd.Month, sd.Day, st.Hours, st.Minutes, st.Seconds)
             & dateVal <= new DateTime(ed.Year, ed.Month, ed.Day, et.Hours, et.Minutes, et.Seconds);
	}
	
	private Metrics ParseLine(string line)
	{
		var log = line.Split(',');
		var time = _utility.GetTime(log[(int)timeIndex], timeformatType);
		var dateVal = GetDateTime(line);
		return new Metrics{  /* fill values here */ }
	}
	
	private string[] GetDateTime(string line)
	{
		var log = line.Split(',');
		return _utility.GetDateTime(dateformatType, log[(int)dateIndex], log[(int)timeIndex]);
	}
	
	public class Metrics{}
