		var groupEntries = from entry in DbSet
						   where entry.Timesheet.UserID == userId &&
								 entry.Timesheet.TimeSheetDate <= endDate.Date &&
								 entry.Timesheet.TimeSheetDate >= startDate.Date
						   group entry by entry.ActivityCode
							   into groupEntry
							   select new
							   {
								   ActivityCode = groupEntry.Key,
								   Duration = Convert.ToInt16(groupEntry.Sum(r => r.Duration))
							   };
		var totalDuration = groupEntries.Sum(r => r.Duration);
		var result = from groupEntry in groupEntries
					 select new TimeSheetSummary()
								{
									ActivityCode = groupEntry.ActivityCode,
									HourSpent = groupEntry.Duration / 60,
									MinuteSpent = groupEntry.Duration % 60,
									Percentage = groupEntry.Duration / totalDuration * 100
								};
