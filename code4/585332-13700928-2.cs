    void ProcessReports {
		string[] fileNames = new string[] { "{0:YYYYMMDD}----1234D.dat", "{0:YYYYMMDD}----5678D.dat" };
		DateTime dateStart = new DateTime(year, month, 1); //start of month
		DateTime dateEnd = dateStart.AddMonths(1); //start of NEXT month (i.e. 1 day past end of this month)
		List<string> lines = new List<string>();
		DateTime date = dateStart;
		while (date < dateEnd) {  //we don't actually get to dateEnd, just the day before it.
			foreach (var fileTemplate in fileNames) {
				//insert the date in YYYYMMDD format
				var file = string.Format(fileTemplate, date);
				if (File.Exists(file)) {
					using (StreamReader reader = new StreamReader(file)) {
						while (!reader.EndOfStream) {
							var line = reader.ReadLine();
							if (true /* insert criteria */)
								lines.Add(line);
						}
					}
				}
			}
			//now jump to next day
			date = date.AddDays(1);
		}	
		//Now we have all the lines. Let's process them;
		foreach (var line in lines) {
			//do something with the report lines
		}
	}
