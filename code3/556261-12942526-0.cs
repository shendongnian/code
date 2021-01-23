    // I group by week number, it seemed clearer to me , but you can change it
	var firstWeek = cal.GetWeekOfYear(DateFrom, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
	var lastWeek  = cal.GetWeekOfYear(DateTo, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
	var q = from b in Bookings
			group b by new { b.Group, b.Type, b.Status }
			into g
			select new 
			{
				Group = g.Key,
				Weeks = 
					from x in g
					select new 
					{ 
						Week = cal.GetWeekOfYear(x.Date,
                                                 dfi.CalendarWeekRule, 
                                                 dfi.FirstDayOfWeek), 
						Item = x 
					}	
			} into gw
			from w in Enumerable.Range(firstWeek, lastWeek-firstWeek+1) 
			select new 
			{ 
				gw.Group,
				Week = w,
				Item = from we in gw.Weeks
					   where we.Week == w
					   group we by we.Item.Group into p 
					   select new 
					   {
					       p.Key,
						   Sum = p.Sum (x => x.Item.Price),
						   Count = p.Count()
					   }
			};
